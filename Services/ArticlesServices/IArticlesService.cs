using maldeaBackend.Dtos.Article;
using maldeaBackend.Models;

namespace maldeaBackend.Services.ArticlesServices;

public interface IArticlesService           
{
    Task<ServiceResponse<List<Article>>> GetAllArticles(int id);
    Task<ServiceResponse<Article>> CreateArticle(RegsterArticles article);
    Task<ServiceResponse<List<Article>>> GetArticles();
    Task<ServiceResponse<List<Article>>> updateArticle();
    Task<ServiceResponse<List<Article>>> deleteArticle();
    
}        