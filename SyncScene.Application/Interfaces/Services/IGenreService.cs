using SyncScene.Domain.Models;

namespace Application.Interfaces.Services;

public interface IGenreService
{
    Task<IEnumerable<Genre>> GetAll();

}