using maldeaBackend.Dtos;
using maldeaBackend.Services.SubscriptionServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace maldeaBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionController:ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionController(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }
    [HttpPost]
    // [Authorize(Roles="user")]
    public async Task<IActionResult> subscriptionPost(AddSubscriptionDto addSubscriptionDto)
    {
        return Ok(await  _subscriptionService.addSubscriber(addSubscriptionDto));
    }   
    
}