using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using SyncScene.DB.Persistence;
using SyncScene.Domain.Exceptions;
using SyncScene.Domain.Models;

namespace SyncScene.DB.Repositories;

public class ArtistRepository : IArtistRepository
{
    
    private readonly AppDbContext _context;
    
    public ArtistRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Artist?> GetById(int id)
    {
        return await _context.Artists.FirstOrDefaultAsync(p => p.Id == id);
    }
    
    public async Task<IEnumerable<Artist>> GetAll()
    {
        return await _context.Artists.AsNoTracking().ToListAsync();
    }

    public async Task<Artist?> Create(Artist entity)
    {
        await _context.Artists.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<Artist?> Update(Artist entity)
    {
        _context.Artists.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task Delete(Artist entity)
    {
        Artist? performer = await _context.Artists.FindAsync(entity.Id);

        if (performer != null)
        {
            _context.Artists.Remove(performer);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new NotFoundException();
        }
    }
}