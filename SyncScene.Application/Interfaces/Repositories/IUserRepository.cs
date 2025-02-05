
using SyncScene.Domain.Models;

namespace Application.Interfaces.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    
    Task<User?> GetById(Ulid id);
    Task<User?> GetByEmail(string email);
    Task<User?> GetByUsername(string username);
    
    Task<User?> GetByPhoneNumber(string phoneNumber);
    
}