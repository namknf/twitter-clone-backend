namespace Twitter_backend.Mappers
{
    using AutoMapper;
    using Twitter_backend.Models;
    using Twitter_backend.Models.ForMappers;
    using Twitter_backend.Responses;

    public class TweetMapper : Profile
    {
        public TweetMapper()
        {
            CreateMap<Tweet, NewTweetModel>()
                .ForMember(destinationMember => destinationMember.Text, memOpt => memOpt.MapFrom(source => source.Text))
                .ForMember(destinationMember => destinationMember.DateTweet, memOpt => memOpt.MapFrom(source => source.DateTweet))
                .ForMember(destinationMember => destinationMember.User, memOpt => memOpt.MapFrom(sourceMember => sourceMember.User))
                .ForMember(destinationMember => destinationMember.UserId, memOpt => memOpt.MapFrom(sourceMember => sourceMember.UserId))
                .ForMember(destinationMember => destinationMember.Id, memberOptions => memberOptions.Ignore())
                ;

            CreateMap<NewTweetModel, Tweet>()
                .ForMember(destinationMember => destinationMember.Text, memOpt => memOpt.MapFrom(source => source.Text))
                .ForMember(destinationMember => destinationMember.DateTweet, memOpt => memOpt.MapFrom(source => source.DateTweet))
                .ForMember(destinationMember => destinationMember.User, memOpt => memOpt.MapFrom(sourceMember => sourceMember.User))
                .ForMember(destinationMember => destinationMember.UserId, memOpt => memOpt.MapFrom(sourceMember => sourceMember.UserId))
                .ForMember(destinationMember => destinationMember.Id, memberOptions => memberOptions.Ignore())
                ;

            CreateMap<Tweet, TweetResponse>()
                .ForMember(dst => dst.Comments, memOpt => memOpt.MapFrom(src => src.Comments))
                .ForMember(dst => dst.DateTweet, memOpt => memOpt.MapFrom(src => src.DateTweet))
                .ForMember(dst => dst.Id, memOpt => memOpt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Text, memOpt => memOpt.MapFrom(src => src.Text))
                .ForMember(dst => dst.User, memOpt => memOpt.MapFrom(src => src.User))
                .ForMember(dst => dst.UserId, memOpt => memOpt.MapFrom(src => src.UserId))
                ;
        }
    }
}
