namespace Twitter_backend.Models
{
    using System;

    public class Comment : ModelBase
    {
        public string Text { get; init; }

        public DateTime DateComment { get; init; }

        public Tweet TweetId { get; init; }

        public User UserId { get; init; }
    }
}
