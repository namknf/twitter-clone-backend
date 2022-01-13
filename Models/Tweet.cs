namespace Twitter_backend.Models
{
    using System;

    public class Tweet
    {
        public int Id { get; init; }

        public string Text { get; set; }

        public DateTime DateTweet { get; init; }

        public Comment[] Comments { get; set; }

        public User[] Likes { get; set; }

        public User UserId { get; init; }
    }
}
