namespace Twitter_backend.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Twitter_backend.Models;

    [Route("/api/comments")]
    [ApiController]
    public class CommentController : Controller
    {
        private CommentsContext _db;

        public CommentController(CommentsContext context)
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
    }
}
