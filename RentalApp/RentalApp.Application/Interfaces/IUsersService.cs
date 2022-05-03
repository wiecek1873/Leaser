using System.Threading.Tasks;
using RentalApp.Application.Dto.Users;

namespace RentalApp.Application.Interfaces
{
    public interface IUsersService
    {
        Task<UserDto> GetUser(string userId);

        Task<UserDto> GetUserByEmail(string email);

        Task<UserDto> CreateUser(RequestUserDto newUserDto);

        Task UpdateUser(string userId, RequestUserDto updatedUserDto);
    }
}
