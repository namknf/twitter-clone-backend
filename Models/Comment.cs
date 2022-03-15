using System;
using System.Collections.Generic;

#nullable disable

namespace Twitter_backend.Models
{
    public partial class Comment
    {
        public int Id { get; set; }

        public string TextComment { get; set; }

        public DateTime DateComment { get; set; }

        public int UserId { get; set; }

        public int TweetId { get; set; }

        public virtual Tweet Tweet { get; set; }

        public virtual User User { get; set; }
    }
}
