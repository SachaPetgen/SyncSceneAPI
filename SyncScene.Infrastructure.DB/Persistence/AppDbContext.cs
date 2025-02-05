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
        // CONFIGS
        
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new UserConfig());

        modelBuilder.ApplyConfiguration(new GenreConfig());
    }
}