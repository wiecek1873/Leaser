using System.Threading.Tasks;
using RentalApp.Application.Dto.Deposits;

namespace RentalApp.Application.Interfaces
{
	public interface IDepositsService
	{
		Task<DepositDto> GetDeposit(int depositId);
		Task<DepositDto> CreateDeposit(RequestDepositDto newDepositDto);
		public Task UpdateDeposit(int depositId, RequestDepositDto updatedDepositDto);
		Task DeleteDeposit(int depositId);
	}
}
