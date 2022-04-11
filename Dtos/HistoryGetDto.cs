namespace maldeaBackend.Dtos;

public class HistoryGetDto
{
    public int id { get; set; }
    public string activityType { get; set; }
    public DateTime Date { get; set; }
    public string activityDesciption { get; set; }
}