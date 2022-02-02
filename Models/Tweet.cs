namespace Twitter_backend.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tweet : ModelBase
    {
        public string Text { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateTweet { get; init; }

        public Comment[] Comments { get; set; }

        [NotMapped]
        public User[] Likes { get; set; }

        public User UserId { get; init; }
    }
}
