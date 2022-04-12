using AutoMapper;
using maldeaBackend.Dtos;
using maldeaBackend.Dtos.Company;
using maldeaBackend.Models;

namespace maldeaBackend;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // CreateMap<User, UserDto>().Include<Reader,ReaderDto>().ReverseMap();
        CreateMap<User, UserRegisterDto>().Include<Reader,ReaderRegisterDto>().ReverseMap();
        CreateMap<User, UserRegisterDto>().Include<Company,CompanyRegisterDto>().ReverseMap();
        // it for Register Mapping
        CreateMap<Reader, ReaderDto>().ReverseMap();
        CreateMap<Company, CompanyRegisterDto>().ReverseMap();
        CreateMap<Reader, ReaderRegisterDto>().ReverseMap();
        CreateMap<User, UserLoginDto>().ReverseMap();
        CreateMap<History, HistoryGetDto>().ReverseMap();
    }
    
}