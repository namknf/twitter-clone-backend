namespace Twitter_backend.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Twitter_backend.Models;

    public class TweetController : Controller
    {
        private TweetsContext _db;

        public TweetController(TweetsContext context)
        {
            _db = context;
        }

        public async Task<IActionResult> Create(Tweet tweet)
        {
            _db.Tweets.Add(tweet);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
