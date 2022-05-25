using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentalApp.Domain.Entities;
using RentalApp.Domain.Interfaces;
using RentalApp.Infrastructure.Data;

namespace RentalApp.Infrastructure.Repositories
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly RentalAppContext _rentalAppContext;

        public TransactionsRepository(RentalAppContext rentalAppContext)
        {
            _rentalAppContext = rentalAppContext;
        }

        public async Task<Transaction> GetTransaction(int transactionId)
        {
            var transaction = await _rentalAppContext.Transactions.SingleOrDefaultAsync(t => t.Id == transactionId);

            return transaction;
        }

        public async Task<Transaction> AddTransaction(Transaction newTransaction)
        {
            newTransaction.Status = TransactionStatus.Borrowed;
            _rentalAppContext.Transactions.Add(newTransaction);
            await _rentalAppContext.SaveChangesAsync();

            return newTransaction;
        }
    }
}
