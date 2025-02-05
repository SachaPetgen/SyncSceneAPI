using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyncScene.Domain.Models;

namespace SyncScene.DB.Persistence.Config;

public class PerformerConfig : IEntityTypeConfiguration<Performer>
{
    public void Configure(EntityTypeBuilder<Performer> builder)
    {
        
        builder.ToTable("Performer");
        
        // ID
        
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.HasKey(p => p.Id)
            .HasName("PK_Performer");
        
        // USERNAME 

        builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();
                
        builder.HasIndex(p => p.Name)
            .IsUnique();
        
        
        builder.Property(p => p.Description)
            .IsRequired();
    }
}