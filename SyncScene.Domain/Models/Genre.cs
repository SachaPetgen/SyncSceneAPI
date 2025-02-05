using SyncScene.Domain.Models.Base;

namespace SyncScene.Domain.Models;

public class Genre : BaseEntity
{
    
    public required int Id { get; set; }
    
    public required string Name { get; set; }
    
}