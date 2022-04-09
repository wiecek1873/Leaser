using System.Threading.Tasks;
using System.Collections.Generic;
using RentalApp.Application.Dto.Users;

namespace RentalApp.Application.Interfaces
{
    public interface IUsersService
    {
        Task<UserDto> CreateUser(CreateUserDto newUserDto);
    }
}
