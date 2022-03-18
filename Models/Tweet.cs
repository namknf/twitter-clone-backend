#nullable disable

namespace Twitter_backend.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// .
    /// </summary>
    public partial class Tweet
    {
        public Tweet()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime DateTweet { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
