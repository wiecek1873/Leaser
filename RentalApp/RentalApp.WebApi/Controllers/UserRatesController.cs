using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalApp.Application.Dto.UserRates;
using RentalApp.Application.Interfaces;
using RentalApp.WebApi.Extensions;
using RentalApp.WebApi.Filters;

namespace RentalApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [GlobalExceptionFilter]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserRatesController : ControllerBase
    {
		private readonly IUserRatesService _userRatesService;

		public UserRatesController(IUserRatesService userRatesService)
		{
			_userRatesService = userRatesService;
		}

		[HttpPost]
		public async Task<IActionResult> AddUserRate([FromBody] RequestUserRateDto requestUserRateDto)
		{
			var newUserRate = await _userRatesService.CreateUserRate(User.GetId(), requestUserRateDto);

			return Created($"api/userRates/{newUserRate.Id}", newUserRate);
		}
	}
}
