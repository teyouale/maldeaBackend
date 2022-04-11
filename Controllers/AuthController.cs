using maldeaBackend.Data;
using maldeaBackend.Dtos;
using maldeaBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace maldeaBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthRepository _authRepository;

    public AuthController(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }
    
    [HttpPost("CRegister")]
    public async Task<IActionResult> Register(ReaderRegisterDto request)
    {
        ServiceResponse<int> response = await _authRepository.CRegister(
            request, request.password);
        if(!response.Success) {
            return BadRequest(response);
        }
        return Ok(response);   
    }
    
    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserLoginDto request)
    {
        ServiceResponse<string> response = await _authRepository.Login(
            request.username, request.password);
        if(!response.Success) {
            return BadRequest(response);
        }
        return Ok(response);
    }
}