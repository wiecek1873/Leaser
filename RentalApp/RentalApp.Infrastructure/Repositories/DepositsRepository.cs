using RentalApp.Domain.Interfaces;
using RentalApp.Domain.Entities;
using System.Threading.Tasks;
using RentalApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace RentalApp.Infrastructure.Repositories
{
	public class DepositsRepository : IDepositsRepository
	{
		private readonly RentalAppContext _rentalAppContext;

		public DepositsRepository(RentalAppContext rentalAppContext)
		{
			_rentalAppContext = rentalAppContext;
		}

		public async Task<Deposit> GetDeposit(int depositId)
		{
			var deposit = await _rentalAppContext.Deposits.SingleOrDefaultAsync(a => a.Id == depositId);

			return deposit;
		}

		public async Task<Deposit> AddDeposit(Deposit newDeposit)
		{
			_rentalAppContext.Deposits.Add(newDeposit);
			await _rentalAppContext.SaveChangesAsync();

			return newDeposit;
		}

		public async Task UpdateDeposit(int depositId, Deposit updatedDeposit)
		{
			var depositToUpdate = await _rentalAppContext.Deposits.SingleOrDefaultAsync(a => a.Id == depositId);

			if (depositToUpdate != null)
			{
				depositToUpdate.Value = updatedDeposit.Value;
				depositToUpdate.PayerId = updatedDeposit.PayerId;
				depositToUpdate.User = updatedDeposit.User;
				depositToUpdate.StatusId = updatedDeposit.StatusId;
				depositToUpdate.DepositStatus = updatedDeposit.DepositStatus;
				depositToUpdate.Posts = updatedDeposit.Posts;
			}

			await _rentalAppContext.SaveChangesAsync();
		}
	}
}
