using Application.DTO.Genre;
using SyncScene.Domain.Models;

namespace Application.Interfaces.Services;

public interface IGenreService
{
    Task<IEnumerable<Genre>> GetAll();
    
    Task<Genre> GetById(int id);
    
    Task<Genre> Create(Genre genre);
    
    Task<Genre> Update(GenreUpdateServiceDTO genreUpdateServiceDto, int id);
    
    Task<Genre> Delete(int id);


}