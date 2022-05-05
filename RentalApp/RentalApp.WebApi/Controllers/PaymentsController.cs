using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Swashbuckle.AspNetCore.Annotations;
using RentalApp.Application.Interfaces;
using RentalApp.WebApi.Filters;
using RentalApp.Application.Dto.Payments;

namespace RentalApp.WebApi.Controllers
{
	[ApiController]
	[GlobalExceptionFilter]
	[Route("api/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class PaymentsController : ControllerBase
	{
		private readonly IPaymentsService _paymentsService;

		public PaymentsController(IPaymentsService paymentsService)
		{
			_paymentsService = paymentsService;
		}

		[HttpGet("{paymentId}")]
		[SwaggerOperation(Summary = "Get payment by id")]
		public async Task<IActionResult> GetPayment(int paymentId)
		{
			var payment = await _paymentsService.GetPayment(paymentId);

			return Ok(payment);
		}

		[HttpPost]
		[SwaggerOperation(Summary = "Add a new payment")]
		public async Task<IActionResult> AddPayment([FromBody] RequestPaymentDto requestPaymentDto)
		{
			var newPayment = await _paymentsService.CreatePayment(requestPaymentDto);

			return Created($"api/categories/{newPayment.Id}", newPayment);
		}

		[HttpPut("{paymentId}")]
		[SwaggerOperation(Summary = "Update a selected payment by id")]
		public async Task<IActionResult> UpdatePayment([FromRoute] int paymentId, [FromBody] RequestPaymentDto updatedPaymentDto)
		{
			await _paymentsService.UpdatePayment(paymentId, updatedPaymentDto);

			return NoContent();
		}

		[HttpDelete("{paymentId}")]
		[SwaggerOperation(Summary = "Delete payment")]
		public async Task<IActionResult> DeletePayment(int paymentId)
		{
			await _paymentsService.DeletePayment(paymentId);

			return Ok();
		}
	}
}
