using AutoMapper;
using maldeaBackend.Data;
using maldeaBackend.Dtos.Newspaper;
using maldeaBackend.Models;
using maldeaBackend.Services.NewspaperServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace maldeaBackend.Controllers;
[ApiController]
[Route("[controller]")]
public class NewspaperController: ControllerBase
{
    private readonly INewspaperServices _newspaperServices;
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly IWebHostEnvironment _environment;

    public NewspaperController(INewspaperServices newspaperServices, IMapper mapper, DataContext context,IWebHostEnvironment environment)
    {
        _newspaperServices = newspaperServices;
        _mapper = mapper;
        _context = context;
        _environment = environment;
    }

    [HttpPost]
    
    public async Task<IActionResult> CreateNewspapers ([FromForm] CreateNewspaperDto createNewspaperDto)
    {
        return Ok(await _newspaperServices.CreateNewspaper(createNewspaperDto));
    }

    [HttpGet]
    [Authorize(Roles="company")]
    public async Task<IActionResult> getNewspaperbyId ()
    {
        return Ok(await _newspaperServices.getNewspaperbyID());
    }
   
}