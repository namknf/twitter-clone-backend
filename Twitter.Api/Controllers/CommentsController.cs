namespace Twitter_backend.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Twitter_backend.Contract;
    using Twitter_backend.Models;
    using Twitter_backend.Requests;
    using Twitter_backend.Responses;
    using Twitter_backend.Services.Comment;

    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost(ApiRoutes.Comments.Create)]
        public async Task<IActionResult> Create([FromBody] CommentRequest request)
        {
            var comment = new Comment()
            {
                DateComment = request.Date,
                TextComment = request.Text,
                User = request.User,
                UserId = request.UserId,
                Tweet = request.Tweet,
                TweetId = request.TweetId,
            };

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var location = $"{baseUrl}/{ApiRoutes.Comments.Get.Replace("{commentId}", comment.Id.ToString())}";

            var itemId = await _commentService.Create(comment);

            comment.Id = itemId;

            var response = new CommentResponse(comment);

            return Created(location, response);
        }

        [HttpDelete(ApiRoutes.Comments.Delete)]
        public async Task<IActionResult> Delete(Comment modelComment)
        {
            var isDeleted = await _commentService.Delete(modelComment);

            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet(ApiRoutes.Comments.GetAll)]
        public Task<IActionResult> GetAllComments()
        {
            var comments = _commentService.GetAllUserComments();

            return Task.FromResult<IActionResult>(Ok(comments));
        }

        [HttpGet(ApiRoutes.Comments.Get)]
        public async Task<IActionResult> GetComment(Comment comment)
        {
            var item = _commentService.GetById(comment.Id);

            if (item == null)
            {
                return await Task.FromResult<IActionResult>(NotFound());
            }

            return Ok(comment);
        }

        [HttpPut(ApiRoutes.Comments.Update)]
        public async Task<IActionResult> UpdateComment([FromRoute] int commentId, [FromBody] CommentRequest request)
        {
            if (commentId == 0)
            {
                return NotFound();
            }

            if (request.UserId != null)
            {
                var userOwnsComment = await _commentService.IsUserOwnsComment((int)request.UserId, commentId);

                if (!userOwnsComment)
                {
                    return BadRequest(new { message = "You don't own this comment" });
                }
            }

            var comment = new Comment()
            {
                Id = commentId,
                TextComment = request.Text,
            };

            var updated = await _commentService.Update(comment);

            if (updated)
            {
                return Ok();
            }

            return BadRequest(new { message = "Something went wrong..." });
        }
    }
}
