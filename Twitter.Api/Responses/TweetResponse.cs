namespace Twitter_backend.Responses
{
    using System;
    using System.Collections.Generic;
    using Twitter_backend.Models;

    public sealed class TweetResponse
    {
        public TweetResponse(Tweet tweet)
        {
            Id = tweet.Id;
            Text = tweet.Text;
            DateTweet = tweet.DateTweet;
            UserId = tweet.UserId;
            User = tweet.User;
            Comments = tweet.Comments;
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime? DateTweet { get; set; }

        public int? UserId { get; set; }

        public User User { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
