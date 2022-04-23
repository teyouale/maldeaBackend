using System.Security.Claims;
using AutoMapper;
using maldeaBackend.Data;
using maldeaBackend.Dtos.Article;
using maldeaBackend.Models;
using maldeaBackend.Services.ArticlesServices;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace maldeaBackend.Services;

public class ArticlesService : IArticlesService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ArticlesService(IMapper mapper, DataContext context, ILogger<ArticlesService> logger,IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }
    
    private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));


    // TODO replace userid -> Newspaper id 
    public async Task<ServiceResponse<List<ArticleGetDto>>> GetAllArticles(int id)
    {
        ServiceResponse<List<ArticleGetDto>> serviceResponse = new ServiceResponse<List<ArticleGetDto>>();
        List<Article> dbArticles =
            await _context.Articles.Include(c => c.Company).Where(c=> c.Company.Id == id).ToListAsync();
        // _logger.LogInformation(JsonConvert.SerializeObject(dbArticles));
        // Mapping list each item to DTO
        serviceResponse.Data = (dbArticles.Select(c => _mapper.Map<ArticleGetDto>(c))).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<ArticleGetDto>> CreateArticle(RegsterArticles article)
    {
        // _logger.LogInformation(GetUserId().ToString());
        ServiceResponse<ArticleGetDto> serviceResponse = new ServiceResponse<ArticleGetDto>();
        Article articleToAdd = _mapper.Map<Article>(article);
        articleToAdd.Company = await _context.Companys.FirstOrDefaultAsync(c => c.Id == GetUserId());
        await _context.Articles.AddAsync(articleToAdd);
        await _context.SaveChangesAsync();
        serviceResponse.Data = _mapper.Map<ArticleGetDto>(articleToAdd);
        return serviceResponse;
    }
    public Task<ServiceResponse<List<Article>>> GetArticles()
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<Article>>> updateArticle()
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<Article>>> deleteArticle()
    {
        throw new NotImplementedException();
    }
}