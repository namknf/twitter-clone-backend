namespace Twitter_backend.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Twitter_backend.Models;

    [Route("api/users/{user-id}/tweets/{tweet-id}/comments")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly CommentsContext _db;

        public CommentsController(CommentsContext context)
        {
            _db = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comment comment)
        {
            _db.Comments.Add(comment);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet("{comment-id}")]
        public async Task<ActionResult<IEnumerable<Comment>>> Get(int id)
        {
            var comment = await _db.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }
    }
}
