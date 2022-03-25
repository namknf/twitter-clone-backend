namespace Twitter_backend.Services.Tweet
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Twitter_backend.Models;

    public interface ITweetService
    {
        Task<int> Create(Tweet model);

        Task<bool> Delete(Tweet model);

        Task<bool> Update(Tweet tweetToUpdate);

        Tweet GetById(int id);

        List<Tweet> GetAllUserTweets();

        Task<bool> IsUserOwnsTweet(int userId, int tweetId);
    }
}
