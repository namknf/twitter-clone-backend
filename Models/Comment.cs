namespace Twitter_backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Comment
    {
        public int CommentId { get; set; }

        public string Text { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateComment { get; set; }

        public Tweet TweetId { get; set; }

        public Profile ProfileId { get; set; }
    }
}
