using SyncScene.Domain.Models;

namespace Application.Interfaces.Repositories;

public interface IPerformerRepository : IBaseRepository<Performer>
{
    
    Task<Performer?> GetById(int id);
    
}