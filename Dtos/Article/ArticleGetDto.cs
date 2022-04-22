using maldeaBackend.Dtos.Company;

namespace maldeaBackend.Dtos.Article;

public class ArticleGetDto
{
    public int Id { get; set; }
    public string heading { get; set; }
    public string subHeading { get; set; }
    public int pageNumber { get; set; }
    public string prority { get; set; }
    public string newspaperID { get; set; }   
    public CompanyGetDto company { get; set; }
}