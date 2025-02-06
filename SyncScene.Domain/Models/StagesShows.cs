namespace SyncScene.Domain.Models;

public class StagesShows
{
    
    public int StageId { get; set; }
    
    public Stage Stage { get; set; }
    
    public int ShowId { get; set; }
    
    public Show Show { get; set; }
    
    public DateTime StartDate { get; set; }
    
}