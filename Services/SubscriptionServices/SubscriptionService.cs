using System.Security.Claims;
using AutoMapper;
using maldeaBackend.Data;
using maldeaBackend.Dtos;
using maldeaBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace maldeaBackend.Services.SubscriptionServices;

public class SubscriptionService:ISubscriptionService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IWebHostEnvironment _environment;

    private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

    public SubscriptionService(IMapper mapper, DataContext context, ILogger<SubscriptionService> logger,IHttpContextAccessor httpContextAccessor,IWebHostEnvironment environment)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
        _environment = environment;

    }
    public async Task<ServiceResponse<GetSubscriptionDto>> addSubscriber(AddSubscriptionDto newSubscription)
    {
        ServiceResponse<GetSubscriptionDto> response = new ServiceResponse<GetSubscriptionDto>();
        Company company = await _context.Companys.FirstOrDefaultAsync(c => c.Id == 1);
        Reader reader = await _context.Readers.FirstOrDefaultAsync(R => R.Id == 2);
        
        Subscription subscription = new Subscription
        {
            Company = company,
            Reader = reader
        };
        
        await _context.Subscriptions.AddAsync(subscription);
        await _context.SaveChangesAsync();
        response.Data = _mapper.Map<GetSubscriptionDto>(subscription);
        return response;
    }
}