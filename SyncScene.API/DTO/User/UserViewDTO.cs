using System.ComponentModel.DataAnnotations;
using SyncScene.Domain.Models;

namespace SyncScene.DTO.User;

public class UserViewDTO
{
    
    [Required]
    public required Ulid Id { get; set; }
    
    [Required]
    public required string Username { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    
    [Required]
    public required Role Role { get; set; }
    
    [Required]
    public required string PhoneNumber { get; set; }

    [Required]
    public required DateTime BirthDate { get; set; }
    
    [Required]
    public required Gender Gender { get; set; }
}