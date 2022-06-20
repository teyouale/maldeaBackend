using maldeaBackend.Dtos.Company;

namespace maldeaBackend.Dtos.Newspaper;

public class NewspaperGetDto
{
    public int id { get; set; }
    public string newspaperName { get; set; }
    public DateTime date { get; set; }
    public CompanyGetDto company { get; set; }
    public string mainHeading { get; set; }
    public string subHeading { get; set; }
    public Boolean isBlocked { get; set; } = false;
    public string uploadeImagePath { get; set; } 
}