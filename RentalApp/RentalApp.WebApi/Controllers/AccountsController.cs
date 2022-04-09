using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using RentalApp.Application.Interfaces;
using RentalApp.WebApi.Filters;
using Microsoft.AspNetCore.Authorization;
using RentalApp.Application.Dto.Users;

namespace RentalApp.WebApi.Controllers
{
    [ApiController]
    [GlobalExceptionFilter]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public AccountsController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Registering an account in the app")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto newUserDto)
        {
            var newUser = await _usersService.CreateUser(newUserDto);

            return Created($"api/users/{newUser.Id}", newUser);
        }
    }
}
