using System;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalApp.WebApi.Extensions;
using RentalApp.WebApi.Filters;
using RentalApp.Application.Dto.Transactions;
using RentalApp.Application.Interfaces;

namespace RentalApp.WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[GlobalExceptionFilter]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class TransactionsController : ControllerBase
	{
		private readonly ITransactionsService _transactionsService;

		public TransactionsController(ITransactionsService transactionsService)
		{
			_transactionsService = transactionsService;
		}


		[HttpGet("{transactionId}")]
		[SwaggerOperation(Summary = "Get transaction by id")]
		public async Task<IActionResult> GetTransaction([FromRoute] int transactionId)
		{
			var transaction = await _transactionsService.GetTransaction(transactionId);

			return Ok(transaction);
		}

		[HttpGet("{postId}/Post")]
		[SwaggerOperation(Summary = "Get transactions by post id")]
		public async Task<IActionResult> GetTransactionsByPostId([FromRoute] int postId)
		{
			var transactions = await _transactionsService.GetTransactionsByPostId(postId);

			return Ok(transactions);
		}

		[HttpGet("{payerId}/Payer")]
		[SwaggerOperation(Summary = "Get transactions by payer id")]
		public async Task<IActionResult> GetTransactionsByPostId([FromRoute] Guid payerId)
		{
			var transactions = await _transactionsService.GetTransactionsByPayerId(payerId);

			return Ok(transactions);
		}

		[HttpPost]
		[SwaggerOperation(Summary = "Add transaction")]
		public async Task<IActionResult> AddTransaction([FromBody] RequestTransactionDto requestTransactionDto)
		{
			var newTransaction = await _transactionsService.CreateTransaction(User.GetId(), requestTransactionDto);

			return Created($"api/transactions/{newTransaction.Id}", newTransaction);
		}

		[HttpPost("{transactionId}/Return")]
		[SwaggerOperation(Summary = "Return item. Set transaction status to returned")]
		public async Task<IActionResult> ReturnItem([FromRoute] int transactionId)
		{
			var transaction = await _transactionsService.ReturnItem(transactionId, User.GetId());

			return Ok(transaction);
		}

		[HttpPost("{transactionId}/Accept")]
		[SwaggerOperation(Summary = "Accept item. Set transaction status to accepted")]
		public async Task<IActionResult> AcceptItem([FromRoute] int transactionId)
		{
			var transaction = await _transactionsService.AcceptItem(transactionId, User.GetId());

			return Ok(transaction);
		}

		[HttpPost("{transactionId}/NonAccept")]
		[SwaggerOperation(Summary = "Non Accept item. Set transaction status to non accepted")]
		public async Task<IActionResult> NonAcceptItem([FromRoute] int transactionId)
		{
			var transaction = await _transactionsService.NonAcceptItem(transactionId, User.GetId());

			return Ok(transaction);
		}
	}
}
