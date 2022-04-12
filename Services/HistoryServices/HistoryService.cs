using System.Security.Claims;
using AutoMapper;
using maldeaBackend.Data;
using maldeaBackend.Dtos;
using maldeaBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace maldeaBackend.Service;

public class HistoryService : IHistoryService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ClaimsPrincipal User { get; }
    private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

    public HistoryService(DataContext context, IMapper mapper,IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ServiceResponse<List<HistoryGetDto>>> GetHistory()
    {
        
        ServiceResponse<List<HistoryGetDto>> serviceResponse = new ServiceResponse<List<HistoryGetDto>>();
        List<History> dbHistory = await _context.History.Where(c => c.Reader.Id == GetUserId()).ToListAsync();
        serviceResponse.Data = dbHistory.Select(c => _mapper.Map<HistoryGetDto>(c)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<HistoryGetDto>>> addHistory(HistoryGetDto historyGetDto)
    {
        // throw new NotImplementedException();
        
        ServiceResponse<List<HistoryGetDto>> serviceResponse = new ServiceResponse<List<HistoryGetDto>>();
        History history = _mapper.Map<History>(historyGetDto);
        history.Reader = await _context.Readers.FirstOrDefaultAsync(u => u.Id == GetUserId());

        await _context.History.AddAsync(history);
        await _context.SaveChangesAsync();

        serviceResponse.Data = (_context.History.Where(c => c.Reader.Id == GetUserId()).Select(c => _mapper.Map<HistoryGetDto>(c))).ToList();
        return serviceResponse;
    }
}