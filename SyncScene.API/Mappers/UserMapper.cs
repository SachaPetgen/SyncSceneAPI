using SyncScene.Domain.Models;
using SyncScene.DTO.User;

namespace SyncScene.Mappers;

public static class UserMapper
{
    public static User ToUser(this UserRegisterDTO userRegisterDto)
    {
        return new User
        {
            Id = Ulid.NewUlid(),
            Username = userRegisterDto.Username,
            Email = userRegisterDto.Email,
            Password = userRegisterDto.Password,
            Role = userRegisterDto.Role,
            PhoneNumber = userRegisterDto.PhoneNumber,
            BirthDate = userRegisterDto.BirthDate,
            Gender = userRegisterDto.Gender
        };
    }

    public static UserViewDTO ToUserViewDTO(this User user)
    {
        return new UserViewDTO()
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            Role = user.Role,
            PhoneNumber = user.PhoneNumber,
            BirthDate = user.BirthDate,
            Gender = user.Gender
        };
    }
}