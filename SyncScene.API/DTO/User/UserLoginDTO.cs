using System.ComponentModel.DataAnnotations;

namespace SyncScene.DTO.User;

public class UserLoginDTO
{
    [Required]
    public required string Identifier { get; set; }
    
    [Required]
    public required string Password { get; set; }

}