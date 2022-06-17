using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace maldeaBackend.Models;

public class Newspaper
{
    public int id { get; set; }
    public string newspaperName { get; set; }
    // public DateTime date { get; set; }
    // public Company company { get; set; }
    public string mainHeading { get; set; }
    public string subHeading { get; set; }
    public Boolean isBlocked { get; set; } = false;
    public IFormFile uploadeImage { get; set; } 
    
 // TODO: Add more fields like Image,Stat
}