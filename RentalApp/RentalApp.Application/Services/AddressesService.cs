using AutoMapper;
using System.Threading.Tasks;
using RentalApp.Application.Exceptions;
using RentalApp.Application.Dto.Addresses;
using RentalApp.Application.Interfaces;
using RentalApp.Domain.Interfaces;
using RentalApp.Domain.Entities;

namespace RentalApp.Application.Services
{
    public class AddressesService : IAddressesService
    {
        private readonly IAddressesRepository _addressesRepository;
        private readonly IMapper _mapper;

        public AddressesService(IAddressesRepository addressesRepository, IMapper mapper)
        {
            _addressesRepository = addressesRepository;
            _mapper = mapper;
        }
        public async Task<AddressDto> CreateAddress(RequestAddressDto newAddressDto)
        {
            if (string.IsNullOrEmpty(newAddressDto.City))
                throw new BadRequestException("City can not be empty");

            if (string.IsNullOrEmpty(newAddressDto.Country))
                throw new BadRequestException("Country can not be empty");

            if (string.IsNullOrEmpty(newAddressDto.Street))
                throw new BadRequestException("Street can not be empty");

            if (string.IsNullOrEmpty(newAddressDto.PostalCode))
                throw new BadRequestException("Postal code not be empty");

            if (string.IsNullOrEmpty(newAddressDto.BuildingNo))
                throw new BadRequestException("Building No not be empty");

            var addressToAdd = _mapper.Map<Address>(newAddressDto);

            await _addressesRepository.AddAddress(addressToAdd);

            return _mapper.Map<AddressDto>(addressToAdd);
        }
    }
}
