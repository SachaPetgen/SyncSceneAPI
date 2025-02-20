﻿using SyncScene.Domain.Models.Base;

namespace SyncScene.Domain.Models;

public class Show : BaseEntity
{
    
    public Show()
    {
        StagesShows = new HashSet<StagesShows>();
    }
    
    public required int Id { get; set; }
    
    public required string Name { get; set; }
    
    public required string? Description { get; set; }
    
    public required int Duration { get; set; }
    
    public int? ArtistId { get; set; }
    
    public Artist? Artist { get; set; }
    
    public ICollection<StagesShows> StagesShows { get; set; }

}