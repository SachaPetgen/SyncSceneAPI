using System.ComponentModel.DataAnnotations;

namespace SyncScene.DTO.Genre;

public class GenreViewDTO
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
}