namespace Twitter_backend.Services.Tweet
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Twitter_backend.Models;
    using Twitter_backend.Repositories;

    internal class TweetService : ITweetService
    {
        private readonly IItemsRepository<Tweet> _itemsRepository;

        public TweetService(IItemsRepository<Tweet> itemsRepository)
        {
            _itemsRepository = itemsRepository;
        }

        public async Task<bool> Delete(Tweet model)
        {
            int affected = await _itemsRepository.Remove(model);

            return affected > 0;
        }

        public Tweet GetById(int id)
        {
            return _itemsRepository.GetById(id);
        }

        public async Task<int> Create(Tweet tweet)
        {
            int addedItem = await _itemsRepository.Add(tweet);

            return addedItem;
        }

        public Task<bool> IsUserOwnsTweet(int userId, int tweetId)
        {
            var tweet = _itemsRepository.GetById(tweetId);

            return Task.FromResult(tweet.UserId == userId);
        }

        public List<Tweet> GetAllUserTweets()
        {
            return _itemsRepository.GetAll();
        }
    }
}
