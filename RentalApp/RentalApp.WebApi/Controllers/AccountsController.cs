using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using RentalApp.Application.Interfaces;
using RentalApp.WebApi.Filters;

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

        [HttpGet]
        [SwaggerOperation(Summary = "Return all users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _usersService.GetUsers();

            return Ok(users);
        }
    }
}
