using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using RentalApp.Application.Dto.Transactions;


namespace RentalApp.Application.Interfaces
{
    public interface ITransactionsService
    {
        Task<TransactionDto> GetTransaction(int transactionId);

        Task<List<TransactionDto>> GetTransactionsByPostId(int postId);

        Task<List<TransactionDto>> GetTransactionsByPayerId(Guid payerId);

        Task<List<TransactionDto>> GetTransactionsByUserId(Guid userId);

        Task<TransactionDto> CreateTransaction(string userId, RequestTransactionDto newTransactionDto);

        Task<TransactionDto> ReturnItem(int transactionId, string payerId);

        Task<TransactionDto> AcceptItem(int transactionId, string userId);

        Task<TransactionDto> NonAcceptItem(int transactionId, string userId);
    }
}
