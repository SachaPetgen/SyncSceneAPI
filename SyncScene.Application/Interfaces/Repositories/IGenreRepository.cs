using SyncScene.Domain.Models;

namespace Application.Interfaces.Repositories;

public interface IGenreRepository : IBaseRepository<Genre>
{

    Task<Genre?> GetById(int id);
    
    Task<Genre?> GetByName(string name);
    
}