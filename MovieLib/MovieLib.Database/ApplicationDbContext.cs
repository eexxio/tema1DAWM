using Microsoft.EntityFrameworkCore;
using MovieLib.Core.Entities;

namespace MovieLib.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Movie entity
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Director).HasMaxLength(100);
        });

        // Configure Review entity
        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Comment).HasMaxLength(1000);
            entity.Property(e => e.ReviewerName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Rating).IsRequired();

            // Configure one-to-many relationship
            entity.HasOne(e => e.Movie)
                  .WithMany(m => m.Reviews)
                  .HasForeignKey(e => e.MovieId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}