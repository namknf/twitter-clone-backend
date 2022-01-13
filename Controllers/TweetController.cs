namespace Twitter_backend.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Twitter_backend.Models;

    [Route("/api/users/{userid}/tweets")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private TweetsContext _db;

        public TweetController(TweetsContext context, IConfiguration config)
        {
            _configuration = config;
            _db = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tweet tweet)
        {
            _db.Tweets.Add(tweet);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet("{tweetid}")]
        public async Task<ActionResult<IEnumerable<Tweet>>> Get(int id)
        {
            Tweet tweet = await _db.Tweets.FirstOrDefaultAsync(x => x.Id == id);

            if (tweet == null)
            {
                return NotFound();
            }

            return new ObjectResult(tweet);
        }
    }
}
