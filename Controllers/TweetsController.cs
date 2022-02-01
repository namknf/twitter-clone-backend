namespace Twitter_backend.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Twitter_backend.Models;

    [Route("api/users/{user-id}/tweets")]
    [ApiController]
    public class TweetsController : Controller
    {
        private readonly TweetsContext _db;

        public TweetsController(TweetsContext context)
        {
            _db = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tweet tweet)
        {
            _db.Tweets.Add(tweet);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet("{tweet-id}")]
        public async Task<ActionResult<IEnumerable<Tweet>>> Get(int id)
        {
            var tweet = await _db.Tweets.FirstOrDefaultAsync(x => x.Id == id);

            if (tweet == null)
            {
                return NotFound();
            }

            return new ObjectResult(tweet);
        }
    }
}
