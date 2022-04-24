using System;
using System.Threading.Tasks;
using RentalApp.Domain.Entities;

namespace RentalApp.Domain.Interfaces
{
    public interface IUserRatesRepository
    {
        Task<UserRate> GetUserRate(int userRateId);

        Task<UserRate> GetUserRateByUsersRelation(Guid userRaterId, Guid userRatedId);

        Task<UserRate> AddUserRate(UserRate newUserRate);
    }
}
