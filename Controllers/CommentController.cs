namespace Twitter_backend.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Twitter_backend.Models;

    [Route("/api/users/{userid}/tweets/{tweetid}/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private CommentsContext _db;

        public CommentController(CommentsContext context, IConfiguration config)
        {
            _configuration = config;
            _db = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comment comment)
        {
            _db.Comments.Add(comment);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet("{commentid}")]
        public async Task<ActionResult<IEnumerable<Comment>>> Get(int id)
        {
            Comment comment = await _db.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if (comment == null)
            {
                return NotFound();
            }

            return new ObjectResult(comment);
        }
    }
}
