using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyncScene.Domain.Models;

namespace SyncScene.DB.Persistence.Config;

public class EventConfig: IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        
        builder.ToTable("Event");
        
        // RELATIONSHIPS

        builder.HasMany(e => e.Stages)
            .WithOne(s => s.Event)
            .HasForeignKey(s => s.EventId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(e => e.CreatedBy)
            .WithMany(u => u.CreatedEvents)
            .HasForeignKey(e => e.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(e => e.Users)
            .WithMany(u => u.SubscribedEvents);
        
        // ID
        
        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.HasKey(e => e.Id)
            .HasName("PK_Event");
        
        // NAME 

        builder.Property(e => e.Name)
            .HasMaxLength(150)
            .IsRequired();
                
        builder.HasIndex(e => e.Name)
            .IsUnique();
        
        // DESCRIPTION
        
        builder.Property(e => e.Description)
            .IsRequired();
        
        // LOCATION
        
        builder.Property(e => e.Location)
            .HasMaxLength(150)
            .IsRequired();
        
        // START DATE
        
        builder.Property(e => e.StartDate)
            .IsRequired();
        
        // END DATE
        
        builder.Property(e => e.EndDate)
            .IsRequired();
    }
}