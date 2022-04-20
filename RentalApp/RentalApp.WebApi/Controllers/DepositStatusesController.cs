using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RentalApp.Application.Interfaces;
using RentalApp.WebApi.Filters;
using RentalApp.Application.Dto.DepositStatuses;
using RentalApp.WebApi.Extensions;

namespace RentalApp.WebApi.Controllers
{
	[ApiController]
	[GlobalExceptionFilter]
	[Route("api/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class DepositStatusesController : ControllerBase
	{
		private readonly IDepositStatusesService _depositStatusesService;

		public DepositStatusesController(IDepositStatusesService depositStatusesService)
		{
			_depositStatusesService = depositStatusesService;
		}

		[HttpGet]
		public async Task<IActionResult> GetDepositStatus(int depositStatusId)
		{
			var deposit = await _depositStatusesService.GetDepositStatus(depositStatusId);

			return Ok(deposit);
		}

		[HttpPost]
		public async Task<IActionResult> AddDepositStatus([FromBody]  CreateDepositStatusDto createDepositStatusDto)
		{
			var newDepositStatus = await _depositStatusesService.CreateDepositStatus(createDepositStatusDto);

			return Created($"api/users/{newDepositStatus.Id}", newDepositStatus);
		}

		[HttpPut("{depositId}")]
		public async Task<IActionResult> UpdateDepositStatus([FromRoute] int depositId, CreateDepositStatusDto updatedDepositStatusDto)
		{
			await _depositStatusesService.UpdateDepositStatus(depositId, updatedDepositStatusDto);

			return NoContent();
		}
	}
}
