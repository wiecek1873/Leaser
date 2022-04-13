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

        public async Task<Address> AddAddress(Address newAddress)
        {
            _rentalAppContext.Addresses.Add(newAddress);
            await _rentalAppContext.SaveChangesAsync();

            return newAddress;
        }
    }
}
