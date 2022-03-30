#nullable disable

namespace Twitter_backend.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Twitter_backend.Models;

    /// <summary>
    /// .
    /// </summary>
    public partial class TwitterContext : DbContext
    {
        public TwitterContext()
        {
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=twitter;Username=postgres;Password=Ye8g6K_r?");
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
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<User>().Property(u => u.Id)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(startValue: 2);
        }
    }
}
