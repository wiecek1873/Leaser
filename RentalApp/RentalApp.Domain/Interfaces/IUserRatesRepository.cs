using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentalApp.Domain.Entities;

namespace RentalApp.Domain.Interfaces
{
    public interface IUserRatesRepository
    {
        Task<UserRate> GetUserRate(int userRateId);

        Task<UserRate> GetUserRateByUsersRelation(Guid userRaterId, Guid userRatedId);

        Task<List<UserRate>> GetUserRatesByUserId(Guid userRaterId);

        Task<UserRate> AddUserRate(UserRate newUserRate);

        Task UpdateUserRate(int userRateId, UserRate updatedUserRate);

        Task DeleteUserRate(int userRateId);
    }
}
