using SyncScene.Domain.Models.Base;

namespace SyncScene.Domain.Models;

public class Artist : BaseEntity
{

    public Artist()
    {
        Genres = new HashSet<Genre>();
    }
    
    public required int Id { get; set; }
    
    public required string Name { get; set; }
    
    public required string? Description { get; set; }
    
    public ICollection<Genre> Genres { get; set; }
    
    public ICollection<Show> Shows { get; set; }

    
}