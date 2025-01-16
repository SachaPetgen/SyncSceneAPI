using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using SyncScene.DB;
using SyncScene.Domain.Exceptions;
using SyncScene.Domain.Models;

namespace Application.Services;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<User?> GetByUlid(string ulid)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.Id == ulid);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.Users.AsNoTracking().ToListAsync();
    }

    public async Task<User?> Create(User entity)
    {
        
        if (await _context.Users.AnyAsync(u => u.Email == entity.Email))
        {
            throw new AlreadyExistException();
        }
        await _context.Users.AddAsync(entity);
        await _context.SaveChangesAsync();
        
        return entity;
        
    }

    public async Task<User?> Update(User entity)
    {
        _context.Users.Update(entity);
        
        await _context.SaveChangesAsync();
        
        return entity;
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
            // Optionally handle the case where the user doesn't exist (throw exception or log)
        }
    }
}