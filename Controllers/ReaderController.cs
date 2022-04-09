using maldeaBackend.Dtos;
using maldeaBackend.Models;
using maldeaBackend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace maldeaBackend.Controllers;

[ApiController]
[Route("[controller]")]

public class ReaderController:ControllerBase
{
    private readonly IReaderService _readerService;

    public ReaderController(IReaderService readerService)
    {
        _readerService = readerService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllReader()
    {
        return Ok(await  _readerService.GetAllReader());
    }   
    // [Authorize]
    // [AllowAnonymous]
    [HttpPost]
    public  async Task<IActionResult> RegisterReader(ReaderDto newreader)
    {
        return Ok(await _readerService.RegisterReader(newreader));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetReader(int id)
    {
        return Ok( await _readerService.GetReaderById(id));
    }

   
}