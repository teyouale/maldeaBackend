using maldeaBackend.Dtos;
using maldeaBackend.Dtos.Company;
using maldeaBackend.Models;

namespace maldeaBackend.Data;

public interface IAuthRepository
{
    Task<ServiceResponse<int>> RRegister(ReaderRegisterDto user, string password);
    Task<ServiceResponse<int>> CRegister(CompanyRegisterDto companyRegisterDto, string password);
    Task<ServiceResponse<string>> Login(string username, string password);
    Task<bool> UserExists(string username);   
}