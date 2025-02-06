using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyncScene.Domain.Models;

namespace SyncScene.DB.Persistence.Config;

public class StagesShowsConfig: IEntityTypeConfiguration<StagesShows>
{
    public void Configure(EntityTypeBuilder<StagesShows> builder)
    {
        
        builder.ToTable("StagesShows");
        
        builder.HasKey(ss => new { ss.StageId, ss.ShowId })
            .HasName("PK_StagesShows");
        
        // RELATIONSHIPS
        
        builder.HasOne(ss => ss.Stage)
            .WithMany(s => s.StagesShows)
            .HasForeignKey(ss => ss.StageId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ss => ss.Show)
            .WithMany(s => s.StagesShows)
            .HasForeignKey(ss => ss.ShowId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // START DATE 

        builder.Property(ss => ss.StartDate)
            .IsRequired();
    }
}