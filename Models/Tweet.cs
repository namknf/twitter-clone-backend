namespace Twitter_backend.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Tweet
    {
        public int Id { get; init; }

        public string Text { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateTweet { get; }

        public Comment[] Comments { get; set; }

        public User[] Likes { get; set; }

        public User UserId { get; init; }
    }
}
