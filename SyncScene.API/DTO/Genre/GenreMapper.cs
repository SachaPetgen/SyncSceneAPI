namespace SyncScene.DTO.Genre;

public static class GenreMapper
{
    
    public static GenreViewDTO ToViewDto(this Domain.Models.Genre genre)
    {
        return new GenreViewDTO
        {
            Id = genre.Id,
            Name = genre.Name
        };
    }
    
    
    
}