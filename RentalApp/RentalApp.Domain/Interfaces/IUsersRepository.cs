using RentalApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalApp.Domain.Interfaces
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetUsers();
    }
}
