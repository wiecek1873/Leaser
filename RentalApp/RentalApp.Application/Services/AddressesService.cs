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
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public AddressesService(IAddressesRepository addressesRepository, IUsersRepository usersRepository, IMapper mapper)
        {
            _addressesRepository = addressesRepository;
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<AddressDto> GetUserAddress(int addressId)
        {
            var address = await _addressesRepository.GetUserAddress(addressId);

            if (address == null)
                throw new NotFoundException("Address with this id does not exist.");

            return _mapper.Map<AddressDto>(address);
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
                throw new BadRequestException("Postal code can not be empty");

            if (string.IsNullOrEmpty(newAddressDto.BuildingNo))
                throw new BadRequestException("Building No can not be empty");

            var addressToAdd = _mapper.Map<Address>(newAddressDto);

            await _addressesRepository.AddAddress(addressToAdd);

            return _mapper.Map<AddressDto>(addressToAdd);
        }

        public async Task UpdateAddress(int addressId, string userId, RequestAddressDto updatedAddressDto)
        {
            var user = await _usersRepository.GetUser(userId);

            if (user.AddressId.HasValue && user.AddressId.Value != addressId)
                throw new MethodNotAllowedException("You can not update address of this user.");

            var addressToUpdate = await _addressesRepository.GetUserAddress(addressId);

            if (addressToUpdate == null)
                throw new NotFoundException("Address with this id does not exist.");

            addressToUpdate = _mapper.Map<Address>(updatedAddressDto);

            await _addressesRepository.UpdateAddress(addressId, addressToUpdate);
        }
    }
}
