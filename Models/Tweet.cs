namespace Twitter_backend.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Tweet
    {
        public int Id { get; set; }

        public string Text { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateTweet { get; }

        public Comment[] Comments { get; set; }

        public Profile[] Likes { get; set; }

        public Profile ProfilesId { get; set; }
    }
}
