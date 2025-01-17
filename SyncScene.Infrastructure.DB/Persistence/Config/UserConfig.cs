﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyncScene.Domain.Models;

namespace SyncScene.DB.Config;

public class UserConfig : IEntityTypeConfiguration<User>
{
    
    public void Configure(EntityTypeBuilder<User> builder)
    {
        
        builder.ToTable("User");
        
        // ID
        
        builder.Property(u => u.Id)
            .HasMaxLength(26)
            .IsRequired();
        
        builder.HasKey(u => u.Id)
            .HasName("PK_User");
        
        // USERNAME 
        
        builder.Property(u => u.Username)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.HasIndex(u => u.Id)
            .IsUnique();
        
        // EMAIL
        
        builder.Property(u => u.Email)
            .HasMaxLength(320)
            .IsRequired();
        
        builder.HasIndex(u => u.Email)
            .IsUnique();
        
        // PASSWORD HASH
        
        builder.Property(u => u.Password)
            .HasMaxLength(512)
            .IsRequired();

        // ROLE
        
        builder.Property(u => u.Role)
            .IsRequired();
        
        // PHONE NUMBER
        
        builder.Property(u => u.PhoneNumber)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.HasIndex(u => u.PhoneNumber)
            .IsUnique();
        
        // BIRTH DATE
        
        builder.Property(u => u.BirthDate)
            .IsRequired();
        
        // GENDER

        builder.Property(u => u.Gender)
            .IsRequired();
    }
}