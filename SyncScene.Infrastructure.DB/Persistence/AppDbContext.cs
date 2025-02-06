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
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Show> Shows { get; set; }
    
    public DbSet<Stage> Stages { get; set; }
    
    public DbSet<StagesShows> StagesShows { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // CONFIGS
        
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new UserConfig());

        modelBuilder.ApplyConfiguration(new GenreConfig());

        modelBuilder.ApplyConfiguration(new ArtistConfig());

        modelBuilder.ApplyConfiguration(new ShowConfig());

        modelBuilder.ApplyConfiguration(new StageConfig());

        modelBuilder.ApplyConfiguration(new StagesShowsConfig());

        modelBuilder.ApplyConfiguration(new EventConfig());
    }
}