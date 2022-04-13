using Microsoft.EntityFrameworkCore;
using RentalApp.Domain.Entities;
using RentalApp.Domain.Interfaces;
using RentalApp.Infrastructure.Data;
using System.Threading.Tasks;

namespace RentalApp.Infrastructure.Repositories
{
    public class AddressesRepository : IAddressesRepository
    {
        private readonly RentalAppContext _rentalAppContext;

        public AddressesRepository(RentalAppContext rentalAppContext)
        {
            _rentalAppContext = rentalAppContext;
        }

        public async Task<Address> GetUserAddress(int addressId)
        {
            var userAddress = await _rentalAppContext.Addresses.SingleOrDefaultAsync(a => a.Id == addressId);

            return userAddress;
        }

        public async Task<Address> AddAddress(Address newAddress)
        {
            _rentalAppContext.Addresses.Add(newAddress);
            await _rentalAppContext.SaveChangesAsync();

            return newAddress;
        }
    }
}
