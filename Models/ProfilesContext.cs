namespace Twitter_backend.Models
{
    using Microsoft.EntityFrameworkCore;

    public class ProfilesContext : DbContext
    {
        public ProfilesContext(DbContextOptions<ProfilesContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
    }
}
