using Microsoft.EntityFrameworkCore;
using camunda_challenge.Models;

namespace camunda_challenge.Data
{
    public class AnimalDbContext : DbContext
    {
        public AnimalDbContext(DbContextOptions<AnimalDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// DbSet for animal pictures
        /// </summary>
        public DbSet<AnimalPicture> AnimalPictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure AnimalPicture entity
            modelBuilder.Entity<AnimalPicture>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FileName).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Format).IsRequired().HasMaxLength(10);
                entity.Property(e => e.FilePath).HasMaxLength(500);
                entity.Property(e => e.AnimalType).HasConversion<string>();
            });
        }
    }
}
