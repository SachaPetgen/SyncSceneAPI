using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using SyncScene.DB.Persistence;
using SyncScene.Domain.Exceptions;
using SyncScene.Domain.Models;

namespace SyncScene.DB.Repositories;

public class PerformerRepository : IPerformerRepository
{
    
    private readonly AppDbContext _context;
    
    public PerformerRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Performer?> GetById(int id)
    {
        return await _context.Performers.FirstOrDefaultAsync(p => p.Id == id);
    }
    
    public async Task<IEnumerable<Performer>> GetAll()
    {
        return await _context.Performers.AsNoTracking().ToListAsync();
    }

    public async Task<Performer?> Create(Performer entity)
    {
        await _context.Performers.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<Performer?> Update(Performer entity)
    {
        _context.Performers.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task Delete(Performer entity)
    {
        Performer? performer = await _context.Performers.FindAsync(entity.Id);

        if (performer != null)
        {
            _context.Performers.Remove(performer);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new NotFoundException();
        }
    }
}