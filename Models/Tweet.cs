namespace Twitter_backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class Tweet
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; }

        public int ProfileId { get; set; }
    }
}
