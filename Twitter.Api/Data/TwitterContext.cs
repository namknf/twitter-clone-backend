#nullable disable

namespace Twitter_backend.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.Extensions.Configuration;
    using Twitter_backend.Models;

    /// <summary>
    /// .
    /// </summary>
    public partial class TwitterContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public TwitterContext()
        {
        }

        public TwitterContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TwitterContext(DbContextOptions<TwitterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Tweet> Tweets { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_configuration["DefaultConnection"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateComment).HasColumnType("date");
            });

            modelBuilder.Entity<Tweet>(entity =>
            {
                entity.ToTable("Tweet");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateTweet).HasColumnType("date");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");
            });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().Property(u => u.Id)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(startValue: 1);
        }
    }
}
