using System.Diagnostics;
using System.Security.Claims;
using AutoMapper;
using maldeaBackend.Dtos;
using maldeaBackend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace maldeaBackend.Controllers;

[Authorize(Roles="user")]
[ApiController]
[Route("[controller]")]
public class HistoryController :ControllerBase
{
    private readonly IHistoryService _historyService;
    private readonly IMapper _mapper;
    
    public HistoryController(IHistoryService historyService)
    {
        _historyService = historyService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllReader()
    {
        return Ok(await _historyService.GetHistory());
    }   
    
    [HttpPost]
    public async Task<IActionResult> addHistory(HistoryGetDto historyGetDto)
    {
        return Ok(await _historyService.addHistory(historyGetDto));
    }   

}