namespace maldeaBackend.Models;

public class User
{
    public int Id { get; set; }
    public string username { get; set; }
    public byte[] passwordHash { get; set; }
    public byte[] passwordSalt { get; set; }
}
 