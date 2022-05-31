using System;
using System.Linq;
using System.Collections.Generic;
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

		public async Task<List<Transaction>> GetTransactionsByPostId(int postId)
		{
			var transactions = await _rentalAppContext.Transactions.Where(t => t.PostId == postId).ToListAsync();

			return transactions;
		}

		public async Task<List<Transaction>> GetTransactionsByPayerId(Guid payerId)
		{
			var transactions = await _rentalAppContext.Transactions.Where(t => t.PayerId == payerId).ToListAsync();

			return transactions;
		}

		public async Task<Transaction> AddTransaction(Transaction newTransaction)
		{
			newTransaction.Status = TransactionStatus.Borrowed;
			_rentalAppContext.Transactions.Add(newTransaction);
			await _rentalAppContext.SaveChangesAsync();

			return newTransaction;
		}

		public async Task<Transaction> ReturnItem(int transactionId)
		{
			var transaction = await _rentalAppContext.Transactions.SingleOrDefaultAsync(t => t.Id == transactionId);
			transaction.Status = TransactionStatus.Returned;
			await _rentalAppContext.SaveChangesAsync();

			return transaction;
		}

		public async Task<Transaction> AcceptItem(int transactionId)
		{
			var transaction = await _rentalAppContext.Transactions.SingleOrDefaultAsync(t => t.Id == transactionId);
			transaction.Status = TransactionStatus.Accepted;
			await _rentalAppContext.SaveChangesAsync();

			return transaction;
		}

		public async Task<Transaction> NonAcceptItem(int transactionId)
		{
			var transaction = await _rentalAppContext.Transactions.SingleOrDefaultAsync(t => t.Id == transactionId);
			transaction.Status = TransactionStatus.NonAccepted;
			await _rentalAppContext.SaveChangesAsync();

			return transaction;
		}
	}
}
