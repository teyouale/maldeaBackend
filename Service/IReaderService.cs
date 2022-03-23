using maldeaBackend.Models;

namespace maldeaBackend.Service;

public interface IReaderService
{
    Task<ServiceResponse<List<Reader>>> GetAllReader();
    Task<ServiceResponse<Reader>> GetReaderById(int id);
    Task<ServiceResponse<List<Reader>>> RegisterReader(Reader newReader);
}