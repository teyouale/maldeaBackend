using AutoMapper;
using maldeaBackend.Dtos;
using maldeaBackend.Dtos.Article;
using maldeaBackend.Dtos.Company;
using maldeaBackend.Dtos.Newspaper;
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
        // CreateMap<Article, RegsterArticles>().ReverseMap();
        // CreateMap<Article, ArticleGetDto>().ReverseMap();
        CreateMap<User, UserGetDto>().Include<Company,CompanyGetDto>().ReverseMap();
        CreateMap<Company, CompanyGetDto>().ReverseMap();
        CreateMap<Company, CompanyMGetDto>().ReverseMap();
        CreateMap<Newspaper, CreateNewspaperDto>().ReverseMap();
        CreateMap<Newspaper, NewspaperGetDto>().ReverseMap();
        
        CreateMap<Subscription, AddSubscriptionDto>().ReverseMap();
        CreateMap<Subscription, GetSubscriptionDto>().ReverseMap();
    }
    
}