using maldeaBackend.Dtos;
using maldeaBackend.Models;

namespace maldeaBackend.Services.SubscriptionServices;

public interface ISubscriptionService
{
        Task<ServiceResponse<GetSubscriptionDto>> addSubscriber(AddSubscriptionDto addSubscriptionDto);


}