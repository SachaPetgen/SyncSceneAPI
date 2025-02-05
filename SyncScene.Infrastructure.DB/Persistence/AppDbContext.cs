using Microsoft.EntityFrameworkCore;
using SyncScene.DB.Persistence.Config;
using SyncScene.Domain.Models;

namespace SyncScene.DB.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> optionsBuilder)
        : base(optionsBuilder) {}
    
    public DbSet<User> Users { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public DbSet<Performer> Performers { get; set; }
    
    public DbSet<Show> Shows { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // CONFIGS
        
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new UserConfig());

        modelBuilder.ApplyConfiguration(new GenreConfig());

        modelBuilder.ApplyConfiguration(new PerformerConfig());

        modelBuilder.ApplyConfiguration(new ShowConfig());
        
    }
}