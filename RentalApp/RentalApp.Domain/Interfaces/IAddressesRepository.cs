using System.Threading.Tasks;
using RentalApp.Domain.Entities;

namespace RentalApp.Domain.Interfaces
{
    public interface IAddressesRepository
    {
        Task<Address> GetUserAddress(int addressId);
        Task<Address> AddAddress(Address newAddress);
    }
}
