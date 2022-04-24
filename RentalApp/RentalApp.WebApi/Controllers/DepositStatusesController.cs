﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RentalApp.Application.Interfaces;
using RentalApp.WebApi.Filters;
using RentalApp.Application.Dto.DepositStatuses;
using Swashbuckle.AspNetCore.Annotations;

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

		[HttpGet("{depositStatusId}")]
		[SwaggerOperation(Summary = "Get deposit status by Id")]
		public async Task<IActionResult> GetDepositStatus(int depositStatusId)
		{
			var deposit = await _depositStatusesService.GetDepositStatus(depositStatusId);

			return Ok(deposit);
		}

		[HttpPost]
		[SwaggerOperation(Summary = "Add deposit status")]
		public async Task<IActionResult> AddDepositStatus([FromBody]  RequestDepositStatusDto createDepositStatusDto)
		{
			var newDepositStatus = await _depositStatusesService.CreateDepositStatus(createDepositStatusDto);

			return Created($"api/depositStatuses/{newDepositStatus.Id}", newDepositStatus);
		}

		[HttpPut("{depositStatusId}")]
		[SwaggerOperation(Summary = "Update deposit status")]
		public async Task<IActionResult> UpdateDepositStatus([FromRoute] int depositStatusId, RequestDepositStatusDto updatedDepositStatusDto)
		{
			await _depositStatusesService.UpdateDepositStatus(depositStatusId, updatedDepositStatusDto);

			return NoContent();
		}

		[HttpDelete("{depositStatusId}")]
		[SwaggerOperation(Summary = "Delete deposit status")]
		public async Task<IActionResult> DeleteDepositStatus(int depositStatusId)
		{
			await _depositStatusesService.DeleteDepositStatus(depositStatusId);

			return Ok();
		}
	}
}
