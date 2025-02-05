using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using SyncScene.Domain.Models;
using SyncScene.DTO.Genre;

namespace SyncScene.Controllers;


[Route("api/[controller]")]
[ApiController]

public class GenreController : ControllerBase
{
    
    private readonly IGenreService _genreService;
    
    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<GenreViewDTO>>> GetAll()
    {
        IEnumerable<Genre> genres = await _genreService.GetAll();
        
        return Ok(genres.Select(g => g.ToViewDto()));
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    
    public async Task<ActionResult<GenreViewDTO>> GetById([FromRoute] int id)
    {

        Genre genre = await _genreService.GetById(id);

        return Ok(genre.ToViewDto());
    }
}