using maldeaBackend.Dtos;
using maldeaBackend.Models;

namespace maldeaBackend.Service;

public interface IHistoryService
{
    Task<ServiceResponse<List<HistoryGetDto>>> GetHistory();
    Task<ServiceResponse<List<HistoryGetDto>>> addHistory(HistoryGetDto historyGetDto);
}