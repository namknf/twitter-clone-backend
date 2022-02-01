namespace Twitter_backend.Models
{
    using Microsoft.EntityFrameworkCore;

    public sealed class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
    }
}
