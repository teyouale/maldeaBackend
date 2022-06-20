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
    private readonly IWebHostEnvironment _environment;


    public NewspaperServices(IMapper mapper, DataContext context, ILogger<NewspaperServices> logger,IHttpContextAccessor httpContextAccessor,IWebHostEnvironment environment)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
        _environment = environment;

    }
    private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));


    public async Task<ServiceResponse<NewspaperGetDto>> CreateNewspaper(CreateNewspaperDto newspaperDto)
    {
        ServiceResponse<NewspaperGetDto> serviceResponse = new ServiceResponse<NewspaperGetDto>();
        Newspaper newspaperToAdd = _mapper.Map<Newspaper>(newspaperDto);
        newspaperToAdd.company = await _context.Companys.FirstOrDefaultAsync(c => c.Id == GetUserId());
        newspaperToAdd.uploadeImagePath = uplodFile(newspaperDto.uploadeImage);
        await _context.Newspapers.AddAsync(newspaperToAdd);
        await _context.SaveChangesAsync();
        serviceResponse.Data = _mapper.Map<NewspaperGetDto>(newspaperToAdd);
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<NewspaperGetDto>>> getNewspaperbyID()
    {
        // throw new NotImplementedException();
        ServiceResponse<List<NewspaperGetDto>> response = new ServiceResponse<List<NewspaperGetDto>>();
        List<Newspaper> newspapers = await _context.Newspapers.Where(c => c.company.Id == GetUserId()).Include((c=>c.company)).ToListAsync();
        response.Data = (newspapers.Select(c => _mapper.Map<NewspaperGetDto>(c))).ToList();
        return response;
    }

    public string uplodFile(IFormFile file)
    {
        
        string directoryPath = Path.Combine(_environment.ContentRootPath, "UploadedFiles");
        string filePath = Path.Combine(directoryPath, file.FileName);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            file.CopyTo(stream);
        }

        return filePath;
    }
}