using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyncScene.Domain.Models;

namespace SyncScene.DB.Persistence.Config;

public class StageConfig : IEntityTypeConfiguration<Stage>
{
    public void Configure(EntityTypeBuilder<Stage> builder)
    {
        
        builder.ToTable("Stage");
        
        // RELATIONSHIPS
        
        // ID
        
        builder.Property(s => s.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.HasKey(s => s.Id)
            .HasName("PK_Stage");
        
        // NAME 

        builder.Property(s => s.Name)
            .HasMaxLength(150)
            .IsRequired();
                
        builder.HasIndex(p => p.Name)
            .IsUnique();

        // CAPACITY 

        builder.Property(s => s.Capacity)
            .IsRequired();
    }
}