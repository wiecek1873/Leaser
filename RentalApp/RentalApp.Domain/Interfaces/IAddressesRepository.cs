using System.Threading.Tasks;
using RentalApp.Domain.Entities;

namespace RentalApp.Domain.Interfaces
{
    public interface IAddressesRepository
    {
        Task<Address> AddAddress(Address newAddress);
    }
}
