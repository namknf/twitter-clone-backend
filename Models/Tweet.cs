namespace Twitter_backend.Models
{
    using System;
    using System.Collections.Generic;

    public class Tweet : ModelBase
    {
        public string Text { get; set; }

        public DateTime DateTweet { get; init; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<User> Likes { get; set; }

        public User UserId { get; init; }
    }
}
