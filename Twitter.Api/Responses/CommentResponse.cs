namespace Twitter_backend.Responses
{
    using System;
    using Twitter_backend.Models;

    public sealed class CommentResponse
    {
        public CommentResponse(Comment comment)
        {
            TextComment = comment.TextComment;
            DateComment = comment.DateComment;
            UserId = comment.UserId;
            TweetId = comment.TweetId;
            Tweet = comment.Tweet;
            User = comment.User;
        }

        public string TextComment { get; set; }

        public DateTime? DateComment { get; set; }

        public int? UserId { get; set; }

        public int? TweetId { get; set; }

        public Tweet Tweet { get; set; }

        public User User { get; set; }
    }
}
