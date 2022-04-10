using RentalApp.Domain.Entities;
using System.Threading.Tasks;

namespace RentalApp.Domain.Interfaces
{
    public interface IUsersRepository
    {
        Task<User> GetUser(string userId);
        Task<User> AddUser(User newUser);
    }
}
