using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApi.Models;

public class DatabaseContext : DbContext
{
    public DatabaseContext (DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().ToTable("Categories");
        modelBuilder.Entity<User>().ToTable("Users");
    }
}
