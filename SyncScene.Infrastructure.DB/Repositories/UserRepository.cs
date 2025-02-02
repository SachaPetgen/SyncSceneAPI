using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using SyncScene.DB;
using SyncScene.DB.Persistence;
using SyncScene.Domain.Exceptions;
using SyncScene.Domain.Models;

namespace SyncScene.DB.Repositories;
public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<User?> GetById(Ulid id)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
    }
    
    public async Task<User?> GetByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(user => string.Equals(user.Email, email));
    }
    
    public async Task<User?> GetByUsername(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(user => string.Equals(user.Username, username));
    }
    
    public async Task<User?> GetByPhoneNumber(string phoneNumber)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.PhoneNumber == phoneNumber);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.Users.AsNoTracking().ToListAsync();
    }

    public async Task<User?> Create(User entity)
    {
        await _context.Users.AddAsync(entity);
        await _context.SaveChangesAsync();
        
        return entity;
        
    }

    public async Task<User?> Update(User updatedEntity)
    {
        _context.Users.Update(updatedEntity);
            
        await _context.SaveChangesAsync();
            
        return updatedEntity;
    }

    public async Task Delete(User entity)
    {
        var user = await _context.Users.FindAsync(entity.Id);
        
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new NotFoundException();
        }
    }
}