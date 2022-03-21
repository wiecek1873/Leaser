using System.Threading.Tasks;
using RentalApp.Application.Dto;
using System.Collections.Generic;

namespace RentalApp.Application.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<UserDto>> GetUsers();
    }
}
