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

			/*
			 * aktulizujemy tylko to co jest w bazi danych a nie relacje z baza
			 * Posts wgl ich nie przekazujesz
			 * tak samo z deposit status przeciezs jak zrobisz mapowanie z dto, które od masz klienta to tam beda nulle i rozwalisz cała baze
			 * bo w dto nie pobierasz tych danych
			 * 
			 */
			if (depositToUpdate != null)
			{
				depositToUpdate.Value = updatedDeposit.Value;
				depositToUpdate.StatusId = updatedDeposit.StatusId;
			}

			await _rentalAppContext.SaveChangesAsync();
		}
	}
}
