using System.Security.Claims;
using AutoMapper;
using maldeaBackend.Data;
using maldeaBackend.Dtos.Article;
using maldeaBackend.Models;
using maldeaBackend.Services.ArticlesServices;
using Microsoft.EntityFrameworkCore;

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
    public async Task<ServiceResponse<List<Article>>> GetAllArticles(int id)
    {
        ServiceResponse<List<Article>> serviceResponse = new ServiceResponse<List<Article>>();
        List<Article> dbArticles = await _context.Articles.Where(c => c.newspaperID == "1").ToListAsync();
        serviceResponse.Data = dbArticles;
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