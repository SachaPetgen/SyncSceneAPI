using SyncScene.Domain.Models.Base;

namespace SyncScene.Domain.Models;

public class Stage : BaseEntity
{
    
    public Stage()
    {
        StagesShows = new HashSet<StagesShows>();
    }
    
    public required int Id { get; set; }
    
    public required string Name { get; set; }
    
    public required int Capacity { get; set; }
    
    public int EventId { get; set; }
    
    public Event Event { get; set; }
    
    public ICollection<StagesShows> StagesShows { get; set; }
    
}