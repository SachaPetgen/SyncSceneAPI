using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Isopoh.Cryptography.Argon2;
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
        entity.Password = HashPassword(entity.Password);
        
        User? user =  await _userRepository.Create(entity);
        
        if (user is null)
        {
            throw new UnableToCreateException();
        }

        return user;
    }
    
    public async Task<User?> Login(string identifier, string password)
    {
        
        User? user = await _userRepository.GetByEmail(identifier);
        
        if (user is null)
        {
            user = await _userRepository.GetByUsername(identifier);
        }
        
        if (user is null)
        {
            throw new InvalidIdentifierException();
        }
        
        if (!VerifyPassword(user.Password, password))
        {
            throw new InvalidPasswordException();
        }

        return user;
    }
    
    private string HashPassword(string password)
    {
        return Argon2.Hash(password);

    }

    public bool VerifyPassword(string hashedPassword, string inputPassword)
    {
        return Argon2.Verify(hashedPassword, inputPassword);
    }
}