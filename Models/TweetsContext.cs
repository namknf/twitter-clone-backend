namespace Twitter_backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class TweetsContext : DbContext
    {
        public TweetsContext(DbContextOptions<TweetsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Tweet> Tweets { get; set; }
    }
}
