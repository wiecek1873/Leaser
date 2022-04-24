using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalApp.Application.Dto.UserRates;
using RentalApp.Application.Interfaces;
using RentalApp.WebApi.Extensions;
using RentalApp.WebApi.Filters;
using Swashbuckle.AspNetCore.Annotations;

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

		[HttpGet("{userRateId}")]
		[SwaggerOperation(Summary = "Get User Rate by Id")]
		public async Task<IActionResult> GetUserRate(int userRateId)
		{
			var userRate = await _userRatesService.GetUserRate(userRateId);

			return Ok(userRate);
		}

		[HttpPost]
		[SwaggerOperation(Summary = "Add User Rate")]
		public async Task<IActionResult> AddUserRate([FromBody] CreateUserRateDto requestUserRateDto)
		{
			var newUserRate = await _userRatesService.CreateUserRate(User.GetId(), requestUserRateDto);

			return Created($"api/userRates/{newUserRate.Id}", newUserRate);
		}

		[HttpPut("{userRateId}")]
		[SwaggerOperation(Summary = "Update a user rate")]
		public async Task<IActionResult> UpdateUserRate([FromRoute] int userRateId, [FromBody] UpdateUserRateDto updatedUserRateDto)
		{
			await _userRatesService.UpdateUserRate(User.GetId(), userRateId, updatedUserRateDto);

			return NoContent();
		}

		[HttpDelete("{userRateId}")]
		[SwaggerOperation(Summary = "Delete a user rate")]
		public async Task<IActionResult> DeleteUserRate(int userRateId)
		{
			await _userRatesService.DeleteUserRate(User.GetId(), userRateId);

			return Ok();
		}
	}
}
