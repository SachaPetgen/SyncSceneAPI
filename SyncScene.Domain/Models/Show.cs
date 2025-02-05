using SyncScene.Domain.Models.Base;

namespace SyncScene.Domain.Models;

public class Show : BaseEntity
{
    
    public required int Id { get; set; }
    
    public required string Name { get; set; }
    
    public required string? Description { get; set; }
    
    
    public required DateTime StartTime { get; set; }

    
    public required DateTime EndTime { get; set; }

}