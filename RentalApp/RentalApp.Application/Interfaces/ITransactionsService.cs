using System.Threading.Tasks;
using RentalApp.Application.Dto.Transactions;


namespace RentalApp.Application.Interfaces
{
    public interface ITransactionsService
    {
        Task<TransactionDto> GetTransaction(int transactionId);

        Task<TransactionDto> CreateTransaction(string userId, RequestTransactionDto newTransactionDto);
    }
}
