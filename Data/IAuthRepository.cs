using maldeaBackend.Dtos;
using maldeaBackend.Models;

namespace maldeaBackend.Data;

public interface IAuthRepository
{
    Task<ServiceResponse<int>> Register(ReaderRegisterDto user, string password);
    Task<ServiceResponse<string>> Login(string username, string password);
    Task<bool> UserExists(string username);   
}