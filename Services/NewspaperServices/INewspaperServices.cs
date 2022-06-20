using maldeaBackend.Dtos.Newspaper;
using maldeaBackend.Models;

namespace maldeaBackend.Services.NewspaperServices;

public interface INewspaperServices
{
    Task<ServiceResponse<NewspaperGetDto>> CreateNewspaper(CreateNewspaperDto newspaperDto);
    
    Task<ServiceResponse<List<NewspaperGetDto>>> getNewspaperbyID ();
}