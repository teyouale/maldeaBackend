namespace maldeaBackend.Dtos;

public class UserDto
{
    public string username { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}