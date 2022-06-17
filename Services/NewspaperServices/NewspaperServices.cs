using System.Security.Claims;
using AutoMapper;
using maldeaBackend.Data;
using maldeaBackend.Dtos.Newspaper;
using maldeaBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace maldeaBackend.Services.NewspaperServices;

public class NewspaperServices : INewspaperServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public NewspaperServices(IMapper mapper, DataContext context, ILogger<NewspaperServices> logger,IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }
    private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));


    public async Task<ServiceResponse<Newspaper>> CreateNewspaper(CreateNewspaperDto newspaperDto)
    {
        // throw new NotImplementedException();
        ServiceResponse<Newspaper> serviceResponse = new ServiceResponse<Newspaper>();
        Newspaper newspaperToAdd = _mapper.Map<Newspaper>(newspaperDto);
        // newspaperToAdd.company = await _context.Companys.FirstOrDefaultAsync(c => c.Id == GetUserId());
        await _context.Newspapers.AddAsync(newspaperToAdd);
        await _context.SaveChangesAsync();
        serviceResponse.Data = newspaperToAdd;
        return serviceResponse;
    }
    
    static string CreateTempfilePath()
    {
        var filename = $"{Guid.NewGuid()}.tmp";
        var directoryPath = Path.Combine("temp", "uploads");
        if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);

        return Path.Combine(directoryPath, filename);
    }
}