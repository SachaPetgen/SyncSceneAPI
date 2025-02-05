using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using SyncScene.Domain.Models;

namespace SyncScene.Controllers;

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
        return Ok(await _genreRepository.GetAll());
    }
    
}