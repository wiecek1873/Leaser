using RentalApp.Domain.Entities;
using System.Threading.Tasks;

namespace RentalApp.Domain.Interfaces
{
    public interface ITransactionsRepository
    {
        Task<Transaction> AddTransaction(Transaction newTransaction);
    }
}
