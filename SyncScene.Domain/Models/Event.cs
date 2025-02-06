using SyncScene.Domain.Models.Base;

namespace SyncScene.Domain.Models;

public class Event : BaseEntity
{
    
    public Event()
    {
        Stages = new HashSet<Stage>();
    }
    
    public required int Id { get; set; }
    
    public required string Name { get; set; }
    
    public required string Description { get; set; }
    
    public required string Location { get; set; }
    
    public required DateTime StartDate { get; set; }
    
    public required DateTime EndDate { get; set; }
    
    public ICollection<Stage> Stages { get; set; }
    
    public User CreatedBy { get; set; }
    
    public Ulid CreatedById { get; set; }
    
    public ICollection<User> Users { get; set; }
    
}