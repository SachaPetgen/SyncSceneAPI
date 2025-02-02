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
    private readonly TokenService _tokenService;
    
    public UserController(IUserService userService, TokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<UserViewDTO>> GetById([FromRoute] string id)
    {
        User? user = await _userService.GetById(Ulid.Parse(id));
        
        if (user is null)
        {
            return NotFound();
        }
        
        return Ok(user.ToUserViewDTO());
    }
    
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<UserRegisterDTO>> Register([FromBody] UserRegisterDTO? userRegisterDto)
    {
        if (userRegisterDto is null || !this.ModelState.IsValid)
        {
            return BadRequest(new { message = "Invalid data" });
        }
        
        User user = await _userService.Register(userRegisterDto.ToUser());
        
        return Ok(new { token = _tokenService.GenerateToken(user) });
    }
    
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<UserViewDTO>> Login([FromBody] UserLoginDTO? userLoginDto)
    {
        if (userLoginDto is null || !this.ModelState.IsValid)
        {
            return BadRequest(new { message = "Invalid data" });
        }
        
        User? user = await _userService.Login(userLoginDto.Identifier, userLoginDto.Password);
        
        if (user is null)
        {
            return Unauthorized();
        }
        
        return Ok(new { token = _tokenService.GenerateToken(user) });
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<UserUpdateDTO>> Update([FromRoute] string id, [FromBody] UserUpdateDTO? userUpdateDto)
    {
        if (userUpdateDto is null || !this.ModelState.IsValid)
        {
            return BadRequest(new { message = "Invalid data" });
        }
        
        User? user = await _userService.Update(userUpdateDto.ToUserUpdateServiceDTO(), Ulid.Parse(id));

        if (user is null)
        {
            return NotFound();
        }
        
        return Ok(user.ToUserViewDTO());
    }
    
    [HttpPatch("changePassword/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<UserUpdateDTO>> Update([FromRoute] string id, [FromBody] UserPatchPasswordDTO? userPatchPasswordDto)
    {
        if (userPatchPasswordDto is null || !this.ModelState.IsValid)
        {
            return BadRequest(new { message = "Invalid data" });
        }
        
        User? user = await _userService.PatchPassword(userPatchPasswordDto.OldPassword!, userPatchPasswordDto.NewPassword!, Ulid.Parse(id));

        if (user is null)
        {
            return NotFound();
        }
        
        return Ok(user.ToUserViewDTO());
    }
    
    
}