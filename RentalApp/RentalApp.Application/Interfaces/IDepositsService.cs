using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalApp.Application.Dto.Deposits;

namespace RentalApp.Application.Interfaces
{
	public interface IDepositsService
	{
		Task<DepositDto> GetDeposit(int depositId);
		Task<DepositDto> CreateDeposit(CreateDepositDto newDepositDto);
		public Task UpdateDeposit(int depositId, CreateDepositDto updatedDepositDto);
	}
}
