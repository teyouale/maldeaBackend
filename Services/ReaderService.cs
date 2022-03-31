using AutoMapper;
using maldeaBackend.Data;
using maldeaBackend.Dtos;
using maldeaBackend.Models;

namespace maldeaBackend.Service;

public class ReaderService : IReaderService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public ReaderService(IMapper mapper,DataContext context)
    {
        _context = context;
        _mapper = mapper;
    }

    private static List<Reader> readers = new List<Reader> {new Reader()};

    public async Task<ServiceResponse<List<ReaderDto>>> GetAllReader()
    {
        ServiceResponse<List<ReaderDto>> serviceResponse = new ServiceResponse<List<ReaderDto>>();
        try
        {
            serviceResponse.Data = (readers.Select(c => _mapper.Map<ReaderDto>(c))).ToList();
        }  catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
        
    }

    public async Task<ServiceResponse<ReaderDto>> GetReaderById(int id)
    {
        ServiceResponse<ReaderDto> serviceResponse = new ServiceResponse<ReaderDto>();
        try{
            serviceResponse.Data = _mapper.Map<ReaderDto>(readers.FirstOrDefault(c => c.Id == id));
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<ReaderDto>>> RegisterReader(ReaderDto newReader)
    {
        ServiceResponse<List<ReaderDto>> serviceResponse = new ServiceResponse<List<ReaderDto>>();
        try
        {
            // Reader
            Reader reader = _mapper.Map<Reader>(newReader);
            reader.Id = readers.Max(c => c.Id) + 1;
            readers.Add(reader);
            serviceResponse.Data = (readers.Select(c => _mapper.Map<ReaderDto>(c))).ToList();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;

    }
}