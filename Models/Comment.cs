namespace Twitter_backend.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; init; }

        public string Text { get; set; }

        public DateTime DateComment { get; init; }

        public Tweet TweetId { get; init; }

        public User UserId { get; init; }
    }
}
