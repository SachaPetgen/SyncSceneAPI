using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
        
        // Make sure all DateTime properties are stored as UTC
        
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime))
                {
                    property.SetValueConverter(
                        new ValueConverter<DateTime, DateTime>(
                            v => DateTime.SpecifyKind(v, DateTimeKind.Utc),  // Convert DateTime to UTC before saving
                            v => v)); // No conversion needed on retrieval
                }
            }
        }
        
        // CONFIGS
        
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new UserConfig());
    }
}