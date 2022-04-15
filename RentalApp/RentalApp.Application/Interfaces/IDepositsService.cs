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
		Task<DepositDto> GetDeposit(int addressId);
		Task<DepositDto> CreateDeposit(CreateDepositDto newAddressDto);
		public Task UpdateDeposit(int addressId, string userId, CreateDepositDto updatedAddressDto);
	}
}
