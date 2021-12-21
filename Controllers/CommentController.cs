namespace Twitter_backend.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Twitter_backend.Models;

    public class CommentController : Controller
    {
        private CommentsContext _db;

        public CommentController(CommentsContext context)
        {
            _db = context;
        }

        public async Task<IActionResult> Create(Comment comment)
        {
            _db.Comments.Add(comment);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
