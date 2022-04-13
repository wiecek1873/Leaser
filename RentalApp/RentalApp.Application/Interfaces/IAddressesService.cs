using System.Threading.Tasks;
using RentalApp.Application.Dto.Addresses;

namespace RentalApp.Application.Interfaces
{
    public interface IAddressesService
    {
        Task<AddressDto> CreateAddress(RequestAddressDto newAddressDto);
    }
}
