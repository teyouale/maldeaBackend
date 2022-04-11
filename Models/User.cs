namespace maldeaBackend.Models;

public enum RoleClass
{
    user = 1,
    company = 2,
    admin = 3
}
public class User
{
    public int Id { get; set; }
    public string username { get; set; }
    public byte[] passwordHash { get; set; }
    public byte[] passwordSalt { get; set; }
    
    public RoleClass Role { get; set; }
}
 