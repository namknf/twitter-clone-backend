namespace Twitter_backend.Mappers
{
    using AutoMapper;
    using Twitter_backend.Models;
    using Twitter_backend.Models.ForMappers;
    using Twitter_backend.Responses;

    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, RegisterModel>()
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password))
                ;

            CreateMap<RegisterModel, User>()
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                ;

            CreateMap<User, AuthorizeResponse>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Nickname, opt => opt.MapFrom(src => src.Nickname))
                .ForMember(dst => dst.Token, opt => opt.Ignore())
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dst => dst.Followers, opt => opt.MapFrom(src => src.Followers))
                .ForMember(dst => dst.Following, opt => opt.MapFrom(src => src.Following))
                .ForMember(dst => dst.Tweets, opt => opt.MapFrom(src => src.Tweets))
                ;
        }
    }
}
