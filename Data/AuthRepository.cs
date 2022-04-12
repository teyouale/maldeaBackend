using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using maldeaBackend.Dtos;
using maldeaBackend.Dtos.Company;
using maldeaBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace maldeaBackend.Data;

public class AuthRepository : IAuthRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;

    public AuthRepository(IMapper mapper,DataContext context,IConfiguration configuration,ILogger<AuthRepository> logger)
    {
        _context = context;
        _mapper = mapper;
        _configuration = configuration;
        _logger = logger;
    }

    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Name,user.username),
            new Claim(ClaimTypes.Role,user.Role.ToString()),
        };
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_configuration.GetSection("AppSettings:Token").Value));
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = creds
        };
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<ServiceResponse<int>> RRegister(ReaderRegisterDto userReaderRegisterDto, string password)
    {
        Reader user = _mapper.Map<Reader>(userReaderRegisterDto);
        user.Role = RoleClass.user;
        // _logger.LogInformation(Newtonsoft.Json.JsonConvert.SerializeObject(user));
        ServiceResponse<int> response = new ServiceResponse<int>();
        if (await UserExists(user.username))
        {
            response.Success = false;
            response.Message = "User already exists.";
            return response;
        }
        
        CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
        user.passwordHash = passwordHash;
        user.passwordSalt = passwordSalt;
        await _context.Readers.AddAsync(user);
        await _context.SaveChangesAsync();
        response.Data = user.Id;
        return response;
    }

    public async Task<ServiceResponse<int>> CRegister(CompanyRegisterDto companyRegisterDto, string password)
    {
        // throw new NotImplementedException();
        Company company = _mapper.Map<Company>(companyRegisterDto);
        company.Role = RoleClass.company;
        // _logger.LogInformation(Newtonsoft.Json.JsonConvert.SerializeObject(user));
        ServiceResponse<int> response = new ServiceResponse<int>();
        if (await UserExists(company.username))
        {
            response.Success = false;
            response.Message = "User already exists.";
            return response;
        }
        
        CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
        company.passwordHash = passwordHash;
        company.passwordSalt = passwordSalt;
        await _context.Companys.AddAsync(company);
        await _context.SaveChangesAsync();
        response.Data = company.Id;
        return response;
    }

    public async Task<ServiceResponse<string>> Login(string username, string password)
    {
        ServiceResponse<string> response = new ServiceResponse<string>();
        User user = await _context.Users.FirstOrDefaultAsync(x => x.username.ToLower().Equals(username.ToLower()));
        if (user == null)
        {
            response.Success = false;
            response.Message = "User not found.";
        }
        else if (!VerifyPasswordHash(password, user.passwordHash, user.passwordSalt))
        {
            response.Success = false;
            response.Message = "Wrong password.";
        }
        else
        {
            response.Data = CreateToken(user);
        }

        return response;
    }

    public async Task<bool> UserExists(string username)
    {
        if (await _context.Users.AnyAsync(x => x.username.ToLower() == username.ToLower()))
        {
            return true;
        }
        return false;
    }
    
    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != passwordHash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}