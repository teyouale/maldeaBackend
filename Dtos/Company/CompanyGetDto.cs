namespace maldeaBackend.Dtos.Company;

public class CompanyGetDto :UserGetDto
{
    
    public string email { get; set; }
    public string phoneNumber { get; set; }
    public string licence { get; set; }
    public string companyDecription { get; set; }
    public string bio { get; set; }
}