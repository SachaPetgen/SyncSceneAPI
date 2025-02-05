using System.ComponentModel.DataAnnotations;

namespace SyncScene.DTO.Genre;

public class GenreDetailsDTO
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
}