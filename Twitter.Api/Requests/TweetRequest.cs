namespace Twitter_backend.Requests
{
    using System;
    using Twitter_backend.Models;

    public class TweetRequest : ModelBase
    {
        public string Text { get; set; }

        public DateTime? DateTweet { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
