namespace Twitter_backend.Mappers
{
    using AutoMapper;
    using Twitter_backend.Entities;
    using Twitter_backend.Models;

    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, AuthorizeResponse>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.NickName, opt => opt.MapFrom(src => src.NickName))
                .ForMember(dst => dst.Token, opt => opt.Ignore())
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dst => dst.Followers, opt => opt.MapFrom(src => src.Followers))
                .ForMember(dst => dst.Following, opt => opt.MapFrom(src => src.Following))
                .ForMember(dst => dst.Tweets, opt => opt.MapFrom(src => src.Tweets))
                ;

            CreateMap<AuthorizeResponse, User>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.NickName, opt => opt.MapFrom(src => src.NickName))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dst => dst.Followers, opt => opt.MapFrom(src => src.Followers))
                .ForMember(dst => dst.Following, opt => opt.MapFrom(src => src.Following))
                .ForMember(dst => dst.Tweets, opt => opt.MapFrom(src => src.Tweets))
                ;
        }
    }
}
