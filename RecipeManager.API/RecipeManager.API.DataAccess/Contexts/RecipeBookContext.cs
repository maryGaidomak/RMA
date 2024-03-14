using Microsoft.EntityFrameworkCore;
using RecipeManager.API.DataAccess.DataClasses;

namespace RecipeManager.API.DataAccess.Contexts;

public class RecipeBookContext : DbContext
{
    public RecipeBookContext(DbContextOptions<RecipeBookContext> options)
    : base(options)
    {
    }

    public DbSet<User> users { get; set; }

    // Not working yet
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .Property(e => e.DateOfBirth)
            .HasConversion(
                v => v,
                v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v
            );
        modelBuilder.Entity<User>()
            .Property(e => e.CreatedAt)
            .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        modelBuilder.Entity<User>()
            .Property(e => e.UpdatedAt)
            .HasConversion(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        modelBuilder.Entity<User>()
          .HasIndex(u => u.Email)
          .IsUnique();
    }
}
