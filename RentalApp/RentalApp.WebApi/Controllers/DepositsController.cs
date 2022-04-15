using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RentalApp.Application.Interfaces;
using RentalApp.WebApi.Filters;
using RentalApp.Application.Dto.Deposits;
using RentalApp.WebApi.Extensions;

namespace RentalApp.WebApi.Controllers
{
	[ApiController]
	[GlobalExceptionFilter]
	[Route("api/[controller]")]
	//todo Zapytac się Adama czy tu też powinna być autoryzacja użytkownika czy cos?
	public class DepositsController : ControllerBase
	{
		private readonly IDepositsService _depositsService;

		public DepositsController(IDepositsService depositService)
		{
			_depositsService = depositService;
		}

		[HttpGet]
		public async Task<IActionResult> GetDeposit(int depositId)
		{
			var post = await _depositsService.GetDeposit(depositId);

			return Ok(post);
		}

		[HttpPut("{depositId}")]
		public async Task<IActionResult> UpdateDeposit([FromRoute] int depositId, CreateDepositDto updatedDepositDto)
		{
			await _depositsService.UpdateDeposit(depositId, updatedDepositDto);

			return NoContent();
		}
	}
}
