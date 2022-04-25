using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RentalApp.Application.Interfaces;
using RentalApp.WebApi.Filters;
using RentalApp.Application.Dto.Deposits;
using Swashbuckle.AspNetCore.Annotations;

namespace RentalApp.WebApi.Controllers
{
	[ApiController]
	[GlobalExceptionFilter]
	[Route("api/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class DepositsController : ControllerBase
	{
		private readonly IDepositsService _depositsService;

		public DepositsController(IDepositsService depositsService)
		{
			_depositsService = depositsService;
		}

		[HttpGet("{depositId}")]
		[SwaggerOperation(Summary = "Get deposit by Id")]
		public async Task<IActionResult> GetDeposit(int depositId)
		{
			var deposit = await _depositsService.GetDeposit(depositId);

			return Ok(deposit);
		}

		[HttpPost]
		[SwaggerOperation(Summary = "Add deposit")]
		public async Task<IActionResult> AddDeposit([FromBody] RequestDepositDto requestDepositDto)
		{
			var newDepositStatus = await _depositsService.CreateDeposit(requestDepositDto);

			return Created($"api/deposits/{newDepositStatus.Id}", newDepositStatus);
		}

		[HttpPut("{depositId}")]
		[SwaggerOperation(Summary = "Update deposit")]
		public async Task<IActionResult> UpdateDeposit([FromRoute] int depositId, RequestDepositDto updatedDepositDto)
		{
			await _depositsService.UpdateDeposit(depositId, updatedDepositDto);

			return NoContent();
		}

		[HttpDelete("{depositId}")]
		[SwaggerOperation(Summary = "Delete deposit")]
		public async Task<IActionResult> DeleteDeposit(int depositId)
		{
			await _depositsService.DeleteDeposit(depositId);

			return Ok();
		}
	}
}
