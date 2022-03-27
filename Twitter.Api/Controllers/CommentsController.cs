namespace Twitter_backend.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Twitter_backend.Contract;
    using Twitter_backend.Models;
    using Twitter_backend.Requests;
    using Twitter_backend.Responses;
    using Twitter_backend.Services.Comment;

    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        /// <summary>
        /// creates a new comment.
        /// </summary>
        /// <param name="request">comment request.</param>
        /// <returns>created comment.</returns>
        /// <response code="201">returns the created comment.</response>
        /// <response code="400">if the comment is null.</response>
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

        /// <summary>
        /// deletes the existing comment.
        /// </summary>
        /// <param name="modelComment">comment.</param>
        /// <returns>deleted comment.</returns>
        /// <response code="201">returns the deleted comment.</response>
        /// <response code="400">if the comment is null.</response>
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

        /// <summary>
        /// gets the all user's comments.
        /// </summary>
        /// <returns>all user's comments.</returns>
        /// <response code="201">returns all comments.</response>
        /// <response code="400">if the comments are null.</response>
        [HttpGet(ApiRoutes.Comments.GetAll)]
        public Task<IActionResult> GetAllComments()
        {
            var comments = _commentService.GetAllUserComments();

            return Task.FromResult<IActionResult>(Ok(comments));
        }

        /// <summary>
        /// gets special comment.
        /// </summary>
        /// <param name="comment">comment.</param>
        /// <returns>the user's comment.</returns>
        /// <response code="201">returns the existing comment.</response>
        /// <response code="400">if the comment is null.</response>
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

        /// <summary>
        /// updates the comment.
        /// </summary>
        /// <param name="commentId">comment's id.</param>
        /// <param name="request">comment model.</param>
        /// <returns>the updated comment.</returns>
        /// <response code="201">returns the updated comment.</response>
        /// <response code="400">if the comment is null.</response>
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
