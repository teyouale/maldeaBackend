using maldeaBackend.Models;
using maldeaBackend.Service;
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
    public IActionResult GetAllReader()
    {
        return Ok(_readerService.GetAllReader());
    }   
    [HttpPost]
    public  IActionResult RegisterReader(Reader newreader)
    {
        return Ok(_readerService.RegisterReader(newreader));
    }

    [HttpGet("{id}")]
    public IActionResult GetReader(int id)
    {
        return Ok(_readerService.GetReaderById(id));
    }

   
}