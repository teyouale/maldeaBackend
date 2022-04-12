using AutoMapper;
using maldeaBackend.Data;
using maldeaBackend.Dtos;
using maldeaBackend.Models;
using Microsoft.EntityFrameworkCore;

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


    public async Task<ServiceResponse<List<ReaderDto>>> GetAllReader()
    {
        ServiceResponse<List<ReaderDto>> serviceResponse = new ServiceResponse<List<ReaderDto>>();
            List<Reader> dbReaders = await _context.Readers.ToListAsync();
            serviceResponse.Data = (dbReaders.Select(c => _mapper.Map<ReaderDto>(c))).ToList();
        return serviceResponse;
        
    }

    public async Task<ServiceResponse<ReaderDto>> GetReaderById(int id)
    {
        ServiceResponse<ReaderDto> serviceResponse = new ServiceResponse<ReaderDto>();
        try{
            Reader dbReader = await _context.Readers.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<ReaderDto>(dbReader);
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
            // Reader
            Reader reader = _mapper.Map<Reader>(newReader);
            await _context.Readers.AddAsync(reader);
            await _context.SaveChangesAsync();
            serviceResponse.Data = (_context.Readers.Select(c => _mapper.Map<ReaderDto>(c))).ToList();
        return serviceResponse;

    }
}