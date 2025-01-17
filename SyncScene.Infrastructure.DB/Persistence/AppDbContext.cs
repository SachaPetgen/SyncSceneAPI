using Microsoft.EntityFrameworkCore;
using SyncScene.DB.Config;
using SyncScene.Domain.Models;

namespace SyncScene.DB.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> optionsBuilder)
        : base(optionsBuilder) {}
    
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        // Ulid VALUE CONVERTER
        
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id)
                .HasConversion(new UlidValueConverter()); // Use the converter
        });

        
        // CONFIGS
        
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new UserConfig());
    }
}