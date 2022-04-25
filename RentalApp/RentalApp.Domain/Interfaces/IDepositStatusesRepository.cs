using System.Threading.Tasks;
using RentalApp.Domain.Entities;

namespace RentalApp.Domain.Interfaces
{
	public interface IDepositStatusesRepository
	{
		Task<DepositStatus> GetDepositStatus(int depositStatusId);
		Task<DepositStatus> AddDepositStatus(DepositStatus newDepositStatus);
		Task UpdateDepositStatus(int depositStatusId, DepositStatus updatedDepositStatus);
		Task DeleteDepositStatus(int depositStatusId);
	}
}
