using maldeaBackend.Models;

namespace maldeaBackend.Service;

public class ReaderService : IReaderService
{
    private static List<Reader> reader = new List<Reader> {new Reader()};

    public async Task<ServiceResponse<List<Reader>>> GetAllReader()
    {
        ServiceResponse<List<Reader>> serviceResponse = new ServiceResponse<List<Reader>>();
        try
        {
            serviceResponse.Data = reader;
        }  catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
        
    }

    public async Task<ServiceResponse<Reader>> GetReaderById(int id)
    {
        ServiceResponse<Reader> serviceResponse = new ServiceResponse<Reader>();
        try{
            serviceResponse.Data = reader.FirstOrDefault(c => c.Id == id);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<Reader>>> RegisterReader(Reader newReader)
    {
        ServiceResponse<List<Reader>> serviceResponse = new ServiceResponse<List<Reader>>();
        try
        {
            reader.Add(newReader);
            serviceResponse.Data = reader;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;

    }
}