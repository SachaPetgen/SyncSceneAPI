using System.ComponentModel.DataAnnotations;

namespace SyncScene.DTO.User;

public class UserPatchPasswordDTO
{
    [Required]
    public string? OldPassword { get; set; }
    
    [Required]
    [MinLength(6)]
    public string? NewPassword { get; set; }
}