using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Npgsql;
using SyncScene.Domain.Exceptions;
using SyncScene.Domain.Models;

namespace Application.Services;

public class UserService : IUserService
{
    
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<User?> GetById(Ulid id)
    {
        User? user = await _userRepository.GetById(id);

        if (user is null)
        {
            throw new NotFoundException();
        }

        return user;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _userRepository.GetAll();
    }

    public async Task<User> Register(User entity)
    {

        entity.CreatedAt = DateTime.UtcNow;
        
        User? user =  await _userRepository.Create(entity);
        
        if (user is null)
        {
            throw new UnableToCreateException();
        }

        return user;
    }
}