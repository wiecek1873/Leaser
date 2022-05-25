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


        [HttpGet("Transaction/{transactionId}")]
        [SwaggerOperation(Summary = "Get transaction by id")]
        public async Task<IActionResult> GetTransaction([FromRoute] int transactionId)
        {
            var transaction = await _transactionsService.GetTransaction(transactionId);

            return Ok(transaction);
        }

        [HttpGet("{postId}")]
        [SwaggerOperation(Summary = "Get transactions by post id")]
        public async Task<IActionResult> GetTransactionsByPostId([FromRoute] int postId)
        {
            var transactions = await _transactionsService.GetTransactionsByPostId(postId);

            return Ok(transactions);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add transaction")]
        public async Task<IActionResult> AddTransaction([FromBody] RequestTransactionDto requestTransactionDto)
        {
            var newTransaction = await _transactionsService.CreateTransaction(User.GetId(), requestTransactionDto);

            return Created($"api/transactions/{newTransaction.Id}", newTransaction);
        }
    }
}
