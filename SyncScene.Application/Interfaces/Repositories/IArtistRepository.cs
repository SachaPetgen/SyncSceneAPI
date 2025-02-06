using SyncScene.Domain.Models;

namespace Application.Interfaces.Repositories;

public interface IArtistRepository : IBaseRepository<Artist>
{
    
    Task<Artist?> GetById(int id);
    
}