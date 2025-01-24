using SyncScene.Domain.Models;
using SyncScene.DTO.User;

namespace Application.Interfaces.Services;

public interface IUserService
{
    Task<User?> GetById(Ulid id);

    Task<IEnumerable<User>> GetAll();

    Task<User> Register(User entity);
    
    Task<User?> Login(string identifier, string password);
    
    Task<User?> Update(UserUpdateServiceDTO entity, Ulid id);
}