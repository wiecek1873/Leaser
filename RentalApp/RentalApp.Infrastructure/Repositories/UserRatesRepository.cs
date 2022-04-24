using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalApp.Infrastructure.Data;
using RentalApp.Domain.Entities;
using RentalApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RentalApp.Infrastructure.Repositories
{
    public class UserRatesRepository : IUserRatesRepository
    {
        private readonly RentalAppContext _rentalAppContext;

        public UserRatesRepository(RentalAppContext rentalAppContext)
        {
            _rentalAppContext = rentalAppContext;
        }

        public async Task<UserRate> GetUserRate(int userRateId)
        {
            var userRate = await _rentalAppContext.UserRates.SingleOrDefaultAsync(u => u.Id == userRateId);

            return userRate;
        }

        public async Task<UserRate> GetUserRateByUsersRelation(Guid userRaterId, Guid userRatedId)
        {
            var userRate = await _rentalAppContext.UserRates.SingleOrDefaultAsync(u => u.RaterUserId == userRaterId && u.RatedUserId == userRatedId);

            return userRate;
        }

        public async Task<UserRate> AddUserRate(UserRate newUserRate)
        {
            _rentalAppContext.UserRates.Add(newUserRate);
            await _rentalAppContext.SaveChangesAsync();

            return newUserRate;
        }
    }
}
