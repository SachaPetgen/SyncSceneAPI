using Application.DTO.Genre;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using SyncScene.Domain.Exceptions;
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

    public async Task<Genre> GetById(int id)
    {
        Genre? genre = await _genreRepository.GetById(id);

        if (genre is null)
        {
            throw new NotFoundException();
        }

        return genre;
    }

    public async Task<Genre> Create(Genre entity)
    {

        if (await _genreRepository.GetByName(entity.Name) is not null)
        {
            throw new AlreadyExistException("Username");
        }
        
        entity.CreatedAt = DateTime.UtcNow;
        
        Genre? genre =  await _genreRepository.Create(entity);
        
        if (genre is null)
        {
            throw new UnableToCreateException();
        }

        return genre;
    }

    public async Task<Genre> Update(GenreUpdateServiceDTO userUpdateServiceDto, int id)
    {
        Genre? updatedGenre = await _genreRepository.GetById(id);

        if (updatedGenre is null)
        {
            throw new NotFoundException();
        }
        
        updatedGenre.Name = userUpdateServiceDto.Name;
        updatedGenre.Description = userUpdateServiceDto.Description;
        
        return await _genreRepository.Update(updatedGenre);
        
    }

    public async Task<Genre> Delete(int id)
    {
        Genre? toDelete = await _genreRepository.GetById(id);

        if (toDelete is null)
        {
            throw new NotFoundException();
        }

        await _genreRepository.Delete(toDelete);

        return toDelete;

    }
}