using SyncScene.Domain.Models.Base;

namespace SyncScene.Domain.Models;

public class Performer : BaseEntity
{
    
    public required int Id { get; set; }
    
    public required string Name { get; set; }

    public required string? Description { get; set; }

}