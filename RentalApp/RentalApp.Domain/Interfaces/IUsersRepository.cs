using RentalApp.Domain.Entities;
using System.Threading.Tasks;

namespace RentalApp.Domain.Interfaces
{
    public interface IUsersRepository
    {
        Task<User> GetUser(string userId);

        Task<User> GetUserByEmail(string email);

        Task<User> AddUser(User newUser);

        Task<bool> UpdateUser(string userId, User updatedUser, string oldPassword);
    }
}
