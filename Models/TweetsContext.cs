namespace Twitter_backend.Models
{
    using Microsoft.EntityFrameworkCore;

    public class TweetsContext : DbContext
    {
        public TweetsContext(DbContextOptions<TweetsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Tweet> Tweets { get; set; } = null!;
    }
}
