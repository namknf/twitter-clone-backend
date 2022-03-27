namespace Twitter_backend.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Twitter_backend.Contract;
    using Twitter_backend.Models;
    using Twitter_backend.Requests;
    using Twitter_backend.Responses;
    using Twitter_backend.Services.Tweet;

    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class TweetsController : Controller
    {
        private readonly ITweetService _tweetService;

        public TweetsController(ITweetService tweetService)
        {
            _tweetService = tweetService;
        }

        /// <summary>
        /// creates a new tweet.
        /// </summary>
        /// <param name="createdTweet">tweet request.</param>
        /// <returns>created tweet.</returns>
        /// <response code="201">returns the created tweet.</response>
        /// <response code="400">if the tweet request is null.</response>
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
            var location = $"{baseUrl}/{ApiRoutes.Tweets.Get.Replace("{tweetId}", tweet.Id.ToString())}";

            int itemId = await _tweetService.Create(tweet);

            tweet.Id = itemId;

            var response = new TweetResponse(tweet);

            return Created(location, response);
        }

        /// <summary>
        /// deletes the tweet.
        /// </summary>
        /// <param name="createdTweet">tweet.</param>
        /// <returns>deleted tweet.</returns>
        /// <response code="201">returns the deleted tweet.</response>
        /// <response code="400">if the tweet is null.</response>
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

        /// <summary>
        /// gets the tweet.
        /// </summary>
        /// <param name="tweet">.</param>
        /// <returns>tweet.</returns>
        /// <response code="201">returns the existing tweet.</response>
        /// <response code="400">if the tweet is null.</response>
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

        /// <summary>
        /// get all user's tweets.
        /// </summary>
        /// <returns>user's tweets.</returns>
        /// <response code="201">returns all user's tweets.</response>
        /// <response code="400">if the tweets are null.</response>
        [HttpGet(ApiRoutes.Tweets.GetAll)]
        public Task<IActionResult> GetAllTweets()
        {
            var tweets = _tweetService.GetAllUserTweets();

            return Task.FromResult<IActionResult>(Ok(tweets));
        }

        /// <summary>
        /// updates the tweet.
        /// </summary>
        /// <param name="tweetId">tweet's id.</param>
        /// <param name="request">tweet request.</param>
        /// <returns>updated tweet.</returns>
        /// <response code="201">returns the updated tweet.</response>
        /// <response code="400">if the tweet is null.</response>
        [HttpPut(ApiRoutes.Tweets.Update)]
        public async Task<IActionResult> UpdateTweet([FromRoute] int tweetId, [FromBody] TweetRequest request)
        {
            if (tweetId == 0)
            {
                return NotFound();
            }

            if (request.UserId != null)
            {
                var userOwnsTweet = await _tweetService.IsUserOwnsTweet((int)request.UserId, tweetId);

                if (!userOwnsTweet)
                {
                    return BadRequest(new { message = "You don't own this tweet" });
                }
            }

            var tweet = new Tweet()
            {
                Id = tweetId,
                Text = request.Text,
            };

            var updated = await _tweetService.Update(tweet);

            if (updated)
            {
                return Ok();
            }

            return BadRequest(new { message = "Something went wrong..." });
        }
    }
}
