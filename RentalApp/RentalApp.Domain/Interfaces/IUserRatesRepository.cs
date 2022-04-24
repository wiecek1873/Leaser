using System.Threading.Tasks;
using RentalApp.Domain.Entities;

namespace RentalApp.Domain.Interfaces
{
    public interface IUserRatesRepository
    {
        Task<UserRate> AddUserRate(UserRate newUserRate);
    }
}
