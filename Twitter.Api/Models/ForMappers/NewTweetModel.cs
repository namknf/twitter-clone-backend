namespace Twitter_backend.Models.ForMappers
{
    using System;

    public class NewTweetModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime? DateTweet { get; set; }

        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
