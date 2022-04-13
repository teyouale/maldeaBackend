using AutoMapper;
using maldeaBackend.Data;
using maldeaBackend.Models;
using maldeaBackend.Services.ArticlesServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]
public class ArticlesController : ControllerBase
{
    private readonly IArticlesService _articlesService;
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public ArticlesController(IArticlesService articlesService)
    {
        _articlesService = articlesService;
    }
    [HttpGet("{id}")]
    // [Authorize]
    public async Task<ActionResult> GetAllArticles(int id)
    {
        // ServiceResponse<List<IActionResult<>
        return Ok(await _articlesService.GetAllArticles(id));
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateArticle(Article article)
    {
        return Ok(await _articlesService.CreateArticle(article));
    }
    
}