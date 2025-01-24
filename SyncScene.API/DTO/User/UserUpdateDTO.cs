using System.ComponentModel.DataAnnotations;

namespace SyncScene.DTO.User;

public class UserUpdateDTO
{
    [Required]
    public required string Username { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    
    [Required]
    public required string PhoneNumber { get; set; }
}