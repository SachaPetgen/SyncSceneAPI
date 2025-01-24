using SyncScene.Domain.Models.Base;

namespace SyncScene.Domain.Models;


public enum Role
{
    Member,
    Admin
}

public enum Gender
{
    Male = 0,
    Female = 1,
    Other = 2
}
public class User : BaseEntity
{
    
    public required Ulid Id { get; set; }

    public string Username { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }
    
    public required Role Role { get; set; }

    public required string PhoneNumber { get; set; }
    
    public required DateTime BirthDate { get; set; }
    
    public required Gender Gender { get; set; }
    
}