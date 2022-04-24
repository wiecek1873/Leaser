using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RentalApp.Application.Interfaces;
using RentalApp.WebApi.Filters;
using RentalApp.Application.Dto.Users;
using RentalApp.WebApi.Extensions;

namespace RentalApp.WebApi.Controllers
{
    [ApiController]
    [GlobalExceptionFilter]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IAddressesService _addressesService;
        private readonly ITokenService _tokenService;

        public AccountsController(IUsersService usersService, IAddressesService addressesService, ITokenService tokenService)
        {
            _usersService = usersService;
            _addressesService = addressesService;
            _tokenService = tokenService;
        }

        [HttpGet]
        [Route("User")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [SwaggerOperation(Summary = "Get a user")]
        public async Task<IActionResult> GetUser()
        {
            var user = await _usersService.GetUser(User.GetId());

            return Ok(user);
        }

        [HttpGet]
        [Route("Email/{email}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [SwaggerOperation(Summary = "Get a user by email")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _usersService.GetUserByEmail(email);

            return Ok(user);
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Register an account in the app")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto newUserDto)
        {
            if (newUserDto.RequestAddressDto == null)
                return BadRequest("Address can not be empty");

            var userAddress = await _addressesService.CreateAddress(newUserDto.RequestAddressDto);

            var createUserDto = new CreateUserDto
            {
                NickName = newUserDto.NickName,
                Name = newUserDto.Name,
                Surname = newUserDto.Surname,
                Email = newUserDto.Email,
                Password = newUserDto.Password,
                PhoneNumber = newUserDto.PhoneNumber,
                AddressId = userAddress?.Id
            };

            var newUser = await _usersService.CreateUser(createUserDto);

            return Created($"api/users/{newUser.Id}", newUser);
        }

        [HttpPost]
        [Route("Authenticate")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Log in to the app")]
        public async Task<IActionResult> GetToken(LoginUserDto loginUserDto)
        {
            var token = await _tokenService.GetToken(loginUserDto);

            if (token == null)
                return BadRequest();

            return Ok(token);
        }
    }
}
