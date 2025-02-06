using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyncScene.Domain.Models;

namespace SyncScene.DB.Persistence.Config;

public class ArtistConfig : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        
        builder.ToTable("Artist");
        
        // RELATIONSHIPS

        builder.HasMany(a => a.Genres)
            .WithMany(g => g.Artists)
            .UsingEntity("ArtistsGenres");

        builder.HasMany(a => a.Shows)
            .WithOne(s => s.Artist)
            .HasForeignKey(s => s.ArtistId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // ID
        
        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.HasKey(a => a.Id)
            .HasName("PK_Artist");
        
        // USERNAME 

        builder.Property(a => a.Name)
            .HasMaxLength(100)
            .IsRequired();
                
        builder.HasIndex(a => a.Name)
            .IsUnique();
        
        // DESCRIPTION
        
        builder.Property(a => a.Description)
            .IsRequired();
    }
}