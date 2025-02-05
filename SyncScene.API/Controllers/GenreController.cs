using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using SyncScene.Domain.Models;
using SyncScene.DTO.Genre;

namespace SyncScene.Controllers;


[Route("api/[controller]")]
[ApiController]

public class GenreController : ControllerBase
{
    
    private readonly IGenreRepository _genreRepository;
    
    public GenreController(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
    {

        IEnumerable<Genre> genres = await _genreRepository.GetAll();
        return Ok(genres.Select(g =>
        {
            return new GenreDetailsDTO
            {
                Id = g.Id,
                Name = g.Name
            };
        }));
    }
    
    
}