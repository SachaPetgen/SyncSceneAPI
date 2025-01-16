using SyncScene.Domain.Models.Base;

namespace SyncScene.Domain.Models;


public enum Role
{
    Member,
    Admin
}
public class User : BaseEntity
{

    public User()
    {
        Id = Ulid.NewUlid().ToString();
    }
    
    public required string Id { get; set; }
    
    public required string Username { get; set; }

    public required string Email { get; set; }

    public required string? Password { get; set; }

    public required int Age { get; set; }
    
    public required Role Role { get; set; }

    public required string PhoneNumber { get; set; }
    
}