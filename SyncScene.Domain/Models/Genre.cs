using SyncScene.Domain.Models.Base;

namespace SyncScene.Domain.Models;

public class Genre : BaseEntity
{

    public Genre()
    {
        Artists = new HashSet<Artist>();
    }
    
    public required int Id { get; set; }
    
    public required string Name { get; set; }
    
    public required string? Description { get; set; }
    
    public ICollection<Artist> Artists { get; set; }
    
}