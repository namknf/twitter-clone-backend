namespace Twitter_backend.Models
{
    using Microsoft.EntityFrameworkCore;

    public class CommentsContext : DbContext
    {
        public CommentsContext(DbContextOptions<CommentsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Comment> Comments { get; set; } = null!;
    }
}
