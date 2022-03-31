using AutoMapper;
using maldeaBackend.Dtos;
using maldeaBackend.Models;

namespace maldeaBackend;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Reader, ReaderDto>();
        // it for Register Mapping
        CreateMap<ReaderDto, Reader>();
    }
    
}