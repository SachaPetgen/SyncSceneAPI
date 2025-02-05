using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using SyncScene.Domain.Models;

namespace Application.Services;

public class GenreService : IGenreService
{
    
    private readonly IGenreRepository _genreRepository;

    public GenreService(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<IEnumerable<Genre>> GetAll()
    {
        return await _genreRepository.GetAll();
    }
    
    
    
    
}