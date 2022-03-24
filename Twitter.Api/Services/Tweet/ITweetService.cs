namespace Twitter_backend.Services.Tweet
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Twitter_backend.Models;
    using Twitter_backend.Requests;

    public interface ITweetService
    {
        Task<int> Create(Tweet model);

        Task<bool> Delete(Tweet model);

        Tweet GetById(int id);

        List<Tweet> GetAllUserTweets();

        Task<bool> IsUserOwnsTweet(int userId, int tweetId);
    }
}
