using System.Collections;

namespace maldeaBackend.Models;

public class Article
{
    public int ArticleId { get; set; }
    public string heading { get; set; }
    public string subHeading { get; set; }
    public int pageNumber { get; set; }
    public string prority { get; set; }
    public Company company { get; set; }
    // change string --> newspaper object    
    // public Newspaper newspaper { get; set; }
    // TODO Tags Attribute
    // TODO Image Attribute   
    // TODO Stat Attribute
}