using System.Threading.Tasks;
using RentalApp.Domain.Entities;

namespace RentalApp.Domain.Interfaces
{
	public interface IDepositsRepository
	{
		Task<Deposit> GetDeposit(int depositId);

		Task<Deposit> AddDeposit(Deposit newDeposit);

		Task UpdateDeposit(int depositId, Deposit updatedDeposit);

		Task DeleteDeposit(int depositId);
	}
}
