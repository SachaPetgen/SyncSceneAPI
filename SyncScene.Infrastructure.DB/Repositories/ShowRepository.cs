using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using SyncScene.DB.Persistence;
using SyncScene.Domain.Exceptions;
using SyncScene.Domain.Models;

namespace SyncScene.DB.Repositories;

public class ShowRepository : IShowRepository
{
    
    private readonly AppDbContext _context;
    
    public ShowRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Show?> GetById(int id)
    {
        return await _context.Shows.FirstOrDefaultAsync(s => s.Id == id);
    }
    
    public async Task<IEnumerable<Show>> GetAll()
    {
        return await _context.Shows.AsNoTracking().ToListAsync();
    }

    public async Task<Show?> Create(Show entity)
    {
        await _context.Shows.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<Show?> Update(Show entity)
    {
        _context.Shows.Update(entity);
        
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task Delete(Show entity)
    {
        Show? show = await _context.Shows.FindAsync(entity.Id);

        if (show != null)
        {
            _context.Shows.Remove(show);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new NotFoundException();
        }
    }
}