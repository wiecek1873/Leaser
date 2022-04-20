﻿using System.Threading.Tasks;
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
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class DepositsController : ControllerBase
	{
		private readonly IDepositsService _depositsService;

		public DepositsController(IDepositsService depositsService)
		{
			_depositsService = depositsService;
		}

		[HttpGet]
		public async Task<IActionResult> GetDeposit(int depositId)
		{
			// jak metoda ma w nazwie deposit nie nazywaj jej post
			var deposit = await _depositsService.GetDeposit(depositId);

			return Ok(deposit);
		}

		/*
		 * [HttpPost]
		 * 
		 * Trzeba dodac metode tworzącą nowy depozyt
		 * Tak samo przed tym dodaniem trzeba stworzyć kontroler, kótry bedzie obsługiwał metody z dodaniem statusu depozytu
		 * 
		 */

		[HttpPut("{depositId}")]
		public async Task<IActionResult> UpdateDeposit([FromRoute] int depositId, RequestDepositDto updatedDepositDto)
		{
			await _depositsService.UpdateDeposit(depositId, updatedDepositDto);

			return NoContent();
		}
	}
}
