using System.Threading.Tasks;
using RentalApp.Application.Dto.Addresses;

namespace RentalApp.Application.Interfaces
{
    public interface IAddressesService
    {
        Task<AddressDto> GetUserAddress(int addressId);
        Task<AddressDto> CreateAddress(RequestAddressDto newAddressDto);
    }
}
