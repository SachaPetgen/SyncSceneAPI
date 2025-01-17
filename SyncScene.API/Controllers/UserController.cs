using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using SyncScene.Domain.Models;
using SyncScene.DTO.User;
using SyncScene.Mappers;

namespace SyncScene.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UserController : ControllerBase
{
    
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<UserRegisterDTO>> Register([FromBody] UserRegisterDTO? userRegisterDto)
    {
        Console.WriteLine(userRegisterDto.ToString());
        if (userRegisterDto is null || !this.ModelState.IsValid)
        {
            return BadRequest(new { message = "Invalid data" });
        }
        
        User user = await _userService.Register(userRegisterDto.ToUser());
        
        return Ok(user.ToUserViewDTO());
    }
}