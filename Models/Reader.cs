namespace maldeaBackend.Models;

public class Reader
{
    // Remove the Default Value
    public int Id { get; set; } = 1;
    public string userName { get; set; } = "tyouale";
    public string password { get; set; } = "123";
    public string phoneNumber { get; set; } = "0938069240";
    public string firstName { get; set; } = "Eyouale";
    public string lastName { get; set; } = "Tensae";
    public string address { get; set; } ="Tensae";
    public string email { get; set; }="Tensae";
    // TODO Image Attribute
    // public string profileImage { get; set; }
    // TODO  Subscriptions Model
    // public List<> subscriptions { get; set; } 
}