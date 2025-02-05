using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using SyncScene.DB.Persistence;
using SyncScene.Domain.Exceptions;
using SyncScene.Domain.Models;

namespace SyncScene.DB.Repositories;

public class GenreRepository : IGenreRepository
{  
    private readonly AppDbContext _context;

    public GenreRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Genre?> GetById(int id)
    {
        return await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<Genre?> GetByName(string name)
    {
        return await _context.Genres.FirstOrDefaultAsync(g => g.Name == name);
    }
    
    public async Task<IEnumerable<Genre>> GetAll()
    {
        return await _context.Genres.AsNoTracking().ToListAsync();

    }

    public async Task<Genre?> Create(Genre entity)
    {
        await _context.Genres.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<Genre?> Update(Genre entity)
    {
        _context.Genres.Update(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task Delete(Genre entity)
    {
        Genre? genre = await _context.Genres.FindAsync(entity.Id);
            
        if(genre != null)
        {
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new NotFoundException();
        }
        
    }
}