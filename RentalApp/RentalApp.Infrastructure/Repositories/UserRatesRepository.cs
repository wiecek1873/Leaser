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

        public async Task<List<UserRate>> GetUserRatesByUserId(Guid ratedUserId)
        {
            var userRates = await _rentalAppContext.UserRates.Where(x => x.RatedUserId == ratedUserId).ToListAsync();

            return userRates;
        }

        public async Task<UserRate> AddUserRate(UserRate newUserRate)
        {
            _rentalAppContext.UserRates.Add(newUserRate);
            await _rentalAppContext.SaveChangesAsync();

            return newUserRate;
        }

        public async Task UpdateUserRate(int userRateId, UserRate updatedUserRate)
        {
            var userRateToUpdate = await _rentalAppContext.UserRates.SingleOrDefaultAsync(u => u.Id == userRateId);

            if (userRateToUpdate != null)
            {
                userRateToUpdate.Rate = updatedUserRate.Rate;
                userRateToUpdate.Comment = updatedUserRate != null ? updatedUserRate.Comment : null;
            }

            await _rentalAppContext.SaveChangesAsync();
        }

        public async Task DeleteUserRate(int userRateId)
        {
            var userRateToDelete = await _rentalAppContext.UserRates.SingleOrDefaultAsync(u => u.Id == userRateId);

            if (userRateToDelete != null)
                _rentalAppContext.UserRates.Remove(userRateToDelete);

            await _rentalAppContext.SaveChangesAsync();
        }
    }
}
