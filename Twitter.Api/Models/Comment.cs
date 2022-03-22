#nullable disable

namespace Twitter_backend.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// .
    /// </summary>
    public partial class Comment : ModelBase
    {
        public string TextComment { get; set; }

        public DateTime? DateComment { get; set; }

        public int? UserId { get; set; }

        public int? TweetId { get; set; }

        public virtual Tweet Tweet { get; set; }

        public virtual User User { get; set; }
    }
}
