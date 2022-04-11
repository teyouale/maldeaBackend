namespace maldeaBackend.Models;

public class History
{
    public int id { get; set; }
    public string activityType { get; set; }
    public DateTime Date { get; set; }
    public string activityDesciption { get; set; }
    public Reader Reader { get; set; }
}