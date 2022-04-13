using System.Collections;

namespace maldeaBackend.Models;

public class Article
{
    public int Id { get; set; }
    public string heading { get; set; }
    public string subHeading { get; set; }
    public int pageNumber { get; set; }
    public string prority { get; set; }
    public Company Company { get; set; }
    // change string --> newspaper object    
    public string newspaperID { get; set; }
    // TODO Tags Attribute
    // TODO Image Attribute   
    // TODO Stat Attribute
}