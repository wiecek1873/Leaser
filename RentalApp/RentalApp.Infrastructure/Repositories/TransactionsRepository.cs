using RentalApp.Domain.Entities;
using RentalApp.Domain.Interfaces;
using RentalApp.Infrastructure.Data;
using System.Threading.Tasks;

namespace RentalApp.Infrastructure.Repositories
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly RentalAppContext _rentalAppContext;

        public TransactionsRepository(RentalAppContext rentalAppContext)
        {
            _rentalAppContext = rentalAppContext;
        }

        public async Task<Transaction> AddTransaction(Transaction newTransaction)
        {
            _rentalAppContext.Transactions.Add(newTransaction);
            await _rentalAppContext.SaveChangesAsync();

            return newTransaction;
        }
    }
}
