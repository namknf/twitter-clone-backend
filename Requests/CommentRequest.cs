namespace Twitter_backend.Requests
{
    using System;
    using Twitter_backend.Models;

    public class CommentRequest
    {
        public string Text { get; set; }

        public DateTime? Date { get; set; }

        public int? UserId { get; set; }

        public int? TweetId { get; set; }

        public virtual Tweet Tweet { get; set; }

        public virtual User User { get; set; }
    }
}
