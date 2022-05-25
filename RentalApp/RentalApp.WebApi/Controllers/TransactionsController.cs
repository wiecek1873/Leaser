using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalApp.Application.Dto.Transactions;
using RentalApp.Application.Interfaces;
using RentalApp.WebApi.Filters;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetTransaction(int transactionId)
        {
            var transaction = await _transactionsService.GetTransaction(transactionId);

            return Ok(transaction);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add transaction")]
        public async Task<IActionResult> AddTransaction([FromBody] RequestTransactionDto requestTransactionDto)
        {
            var newTransaction = await _transactionsService.CreateTransaction(requestTransactionDto);

            return Created($"api/transactions/{newTransaction.Id}", newTransaction);
        }
    }
}
