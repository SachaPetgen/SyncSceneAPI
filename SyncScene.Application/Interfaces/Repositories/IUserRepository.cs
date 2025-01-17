
using SyncScene.Domain.Models;

namespace Application.Interfaces.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    
    Task<User?> GetById(Ulid id);
    
}