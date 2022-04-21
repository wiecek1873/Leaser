using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RentalApp.WebApi.Filters;
using RentalApp.WebApi.Extensions;
using RentalApp.Application.Interfaces;
using RentalApp.Application.Dto.Addresses;

namespace RentalApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [GlobalExceptionFilter]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressesService _addressesService;
        private readonly IUsersService _usersService;

        public AddressesController(IAddressesService addressesService, IUsersService usersService)
        {
            _addressesService = addressesService;
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserAddress()
        {
            var user = await _usersService.GetUser(User.GetId());

            if (!user.AddressId.HasValue)
                return NotFound("User has not added an address.");

            var userAddress = await _addressesService.GetUserAddress(user.AddressId.Value);

            return Ok(userAddress);
        }

        [HttpPut("{addressId}")]
        public async Task<IActionResult> UpdateAddress([FromRoute] int addressId, RequestAddressDto updatedAddressDto)
        {
            await _addressesService.UpdateAddress(addressId, User.GetId(), updatedAddressDto);

            return NoContent();
        }
    }
}
