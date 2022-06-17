using maldeaBackend.Dtos.Newspaper;
using maldeaBackend.Models;

namespace maldeaBackend.Services.NewspaperServices;

public interface INewspaperServices
{
    Task<ServiceResponse<Newspaper>> CreateNewspaper(CreateNewspaperDto newspaperDto);
}