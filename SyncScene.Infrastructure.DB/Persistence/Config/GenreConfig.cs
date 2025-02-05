using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyncScene.Domain.Models;

namespace SyncScene.DB.Persistence.Config;

public class GenreConfig : IEntityTypeConfiguration<Genre>
{

    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable("Genre");
        
        // ID
        
        builder.Property(g => g.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.HasKey(g => g.Id)
            .HasName("PK_Genre");
        
        // USERNAME 

        builder.Property(g => g.Name)
            .HasMaxLength(100)
            .IsRequired();
                
        builder.HasIndex(u => u.Name)
            .IsUnique();
        
        
        builder.Property(g => g.Description)
            .IsRequired();
    }
}