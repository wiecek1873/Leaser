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

        public async Task UpdateAddress(int addressId, Address updatedAddress)
        {
            var addressToUpdate = await _rentalAppContext.Addresses.SingleOrDefaultAsync(a => a.Id == addressId);

            if (addressToUpdate != null)
            {
                addressToUpdate.Country = updatedAddress.Country;
                addressToUpdate.City = updatedAddress.City;
                addressToUpdate.Street = updatedAddress.Street;
                addressToUpdate.BuildingNo = updatedAddress.BuildingNo;
                addressToUpdate.ApartmentNo = !string.IsNullOrEmpty(updatedAddress.ApartmentNo) ? updatedAddress.ApartmentNo : string.Empty;
                addressToUpdate.PostalCode = updatedAddress.PostalCode;
            }

            await _rentalAppContext.SaveChangesAsync();
        }
    }
}
