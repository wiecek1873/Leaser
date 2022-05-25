using System.Threading.Tasks;
using System.Collections.Generic;
using RentalApp.Application.Dto.Transactions;


namespace RentalApp.Application.Interfaces
{
    public interface ITransactionsService
    {
        Task<TransactionDto> GetTransaction(int transactionId);

        Task<List<TransactionDto>> GetTransactionsByPostId(int postId);

        Task<TransactionDto> CreateTransaction(string userId, RequestTransactionDto newTransactionDto);
    }
}
