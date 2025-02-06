using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyncScene.Domain.Models;

namespace SyncScene.DB.Persistence.Config;

public class ShowConfig : IEntityTypeConfiguration<Show>
{
    public void Configure(EntityTypeBuilder<Show> builder)
    {
        
        builder.ToTable("Show");
        
        // ID
        
        builder.Property(s => s.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.HasKey(s => s.Id)
            .HasName("PK_Show");
        
        // USERNAME 

        builder.Property(s => s.Name)
            .HasMaxLength(100)
            .IsRequired();
                
        builder.HasIndex(p => p.Name)
            .IsUnique();
        
        // DESCRIPTION
        
        builder.Property(p => p.Description)
            .IsRequired();
        
        // DURATTION
        
        builder.Property(p => p.Duration)
            .IsRequired();

        
    }
}