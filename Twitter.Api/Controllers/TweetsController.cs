namespace Twitter_backend.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Twitter_backend.Contract;
    using Twitter_backend.Models;
    using Twitter_backend.Requests;
    using Twitter_backend.Responses;
    using Twitter_backend.Services.Tweet;

    [ApiController]
    internal class TweetsController : Controller
    {
        private readonly ITweetService _tweetService;

        public TweetsController(ITweetService tweetService)
        {
            _tweetService = tweetService;
        }

        [HttpPost(ApiRoutes.Tweets.Create)]
        public async Task<IActionResult> Create([FromBody] TweetRequest createdTweet)
        {
            var tweet = new Tweet()
            {
                Text = createdTweet.Text,
                User = createdTweet.User,
                UserId = createdTweet.UserId,
                DateTweet = createdTweet.DateTweet,
            };

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var location = $"{baseUrl}/{ApiRoutes.Tweets.Get.Replace("{guidId}", tweet.Id.ToString())}";

            int itemId = await _tweetService.Create(tweet);

            tweet.Id = itemId;

            var response = new TweetResponse(tweet);

            return Created(location, response);
        }

        [HttpDelete(ApiRoutes.Tweets.Delete)]
        public async Task<IActionResult> Delete(Tweet createdTweet)
        {
            bool isDeleted = await _tweetService.Delete(createdTweet);

            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet(ApiRoutes.Tweets.Get)]
        public async Task<IActionResult> GetTweet(Tweet tweet)
        {
            var item = _tweetService.GetById(tweet.Id);

            if (item == null)
            {
                return await Task.FromResult<IActionResult>(NotFound());
            }

            return Ok(item);
        }
    }
}
