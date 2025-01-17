using SyncScene.Domain.Models;

namespace Application.Interfaces.Services;

public interface IUserService
{
    Task<User?> GetById(Ulid id);

    Task<IEnumerable<User>> GetAll();

    Task<User> Register(User entity);
}