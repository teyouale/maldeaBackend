using maldeaBackend.Dtos;
using maldeaBackend.Models;

namespace maldeaBackend.Service;

public interface IReaderService
{
    Task<ServiceResponse<List<ReaderDto>>> GetAllReader();
    Task<ServiceResponse<ReaderDto>> GetReaderById(int id);
    Task<ServiceResponse<List<ReaderDto>>> RegisterReader(ReaderDto newReader);
}