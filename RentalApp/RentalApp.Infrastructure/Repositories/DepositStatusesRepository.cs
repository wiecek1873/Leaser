using Microsoft.EntityFrameworkCore;
using RentalApp.Domain.Entities;
using RentalApp.Domain.Interfaces;
using RentalApp.Infrastructure.Data;
using System.Threading.Tasks;

namespace RentalApp.Infrastructure.Repositories
{
	public class DepositStatusesRepository : IDepositStatusesRepository
	{
		private readonly RentalAppContext _rentalAppContext;

		public DepositStatusesRepository(RentalAppContext rentalAppContext)
		{
			_rentalAppContext = rentalAppContext;
		}

		public async Task<DepositStatus> GetDepositStatus(int depositStatusId)
		{
			var depositStatus = await _rentalAppContext.DepositStatuses.SingleOrDefaultAsync(d => d.Id == depositStatusId);

			return depositStatus;
		}

		public async Task<DepositStatus> AddDepositStatus(DepositStatus newDepositStatus)
		{
			_rentalAppContext.DepositStatuses.Add(newDepositStatus);
			await _rentalAppContext.SaveChangesAsync();

			return newDepositStatus;
		}

		public async Task UpdateDepositStatus(int depositStatusId, DepositStatus updatedDepositStatus)
		{
			var depositStatusToUpdate = await _rentalAppContext.DepositStatuses.SingleOrDefaultAsync(d => d.Id == depositStatusId);

			if (depositStatusToUpdate != null)
			{
				depositStatusToUpdate.Status = updatedDepositStatus.Status;
				depositStatusToUpdate.Description = updatedDepositStatus.Description;
			}

			await _rentalAppContext.SaveChangesAsync();
		}

		public async Task DeleteDepositStatus(int depositStatusId)
		{
			var depositStatusToDelete = await _rentalAppContext.DepositStatuses.SingleOrDefaultAsync(d => d.Id == depositStatusId);

			if (depositStatusToDelete != null)
				_rentalAppContext.DepositStatuses.Remove(depositStatusToDelete);

			await _rentalAppContext.SaveChangesAsync();
		}
	}
}
