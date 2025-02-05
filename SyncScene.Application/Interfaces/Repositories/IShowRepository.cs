using SyncScene.Domain.Models;

namespace Application.Interfaces.Repositories;

public interface IShowRepository : IBaseRepository<Show>
{

    Task<Show?> GetById(int id);
    
    
    
    
    
}