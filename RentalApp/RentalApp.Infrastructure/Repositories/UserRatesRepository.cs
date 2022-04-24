using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalApp.Infrastructure.Data;
using RentalApp.Domain.Entities;
using RentalApp.Domain.Interfaces;

namespace RentalApp.Infrastructure.Repositories
{
    public class UserRatesRepository : IUserRatesRepository
    {
        private readonly RentalAppContext _rentalAppContext;

        public UserRatesRepository(RentalAppContext rentalAppContext)
        {
            _rentalAppContext = rentalAppContext;
        }

        public async Task<UserRate> AddUserRate(UserRate newUserRate)
        {
            _rentalAppContext.UserRates.Add(newUserRate);
            await _rentalAppContext.SaveChangesAsync();

            return newUserRate;
        }
    }
}
