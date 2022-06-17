namespace maldeaBackend.Dtos.Newspaper;

public class CreateNewspaperDto
{
    public int newspaperId { get; set; }
    public string newspaperName { get; set; }
    public DateTime date { get; set; }
    public string mainHeading { get; set; }
    public string subHeading { get; set; }
    public Boolean isBlocked { get; set; }
}