namespace Twitter_backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class ProfilesContext : DbContext
    {
        public ProfilesContext(DbContextOptions<ProfilesContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Profile> Profiles { get; set; }
    }
}
