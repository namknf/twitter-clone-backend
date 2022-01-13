namespace Twitter_backend.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; init; }

        public string Text { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateComment { get; }

        public Tweet TweetId { get; init; }

        public User UserId { get; init; }
    }
}
