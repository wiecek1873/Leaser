using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using RentalApp.Domain.Entities;

namespace RentalApp.Domain.Interfaces
{
    public interface ITransactionsRepository
    {
        Task<Transaction> GetTransaction(int transactionId);

        Task<List<Transaction>> GetTransactionsByPostId(int postId);

        Task<List<Transaction>> GetTransactionsByPayerId(Guid payerId);

        Task<Transaction> AddTransaction(Transaction newTransaction);

        Task<Transaction> ReturnItem(int transactionId);

        Task<Transaction> AcceptItem(int transactionId);
    }
}
