using Microsoft.EntityFrameworkCore;
using SyncScene.DB;
using SyncScene.Domain.Models;

namespace Application.Interfaces.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    
    Task<User?> GetByUlid(string ulid);

    
}