using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SyncScene.DB.Persistence;

public class UlidValueConverter : ValueConverter<Ulid, string>
{
    public UlidValueConverter() 
        : base(
            ulid => ulid.ToString(),  // Convert ULid to string for storage
            str => Ulid.Parse(str))   // Convert string back to ULid when reading
    { }
}