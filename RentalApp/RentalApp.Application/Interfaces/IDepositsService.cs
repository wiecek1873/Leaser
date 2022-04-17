﻿using System.Threading.Tasks;
using RentalApp.Application.Dto.Deposits;

namespace RentalApp.Application.Interfaces
{
	public interface IDepositsService
	{
		Task<DepositDto> GetDeposit(int depositId);
		Task<DepositDto> CreateDeposit(CreateDepositDto newDepositDto);
		public Task UpdateDeposit(int depositId, UpdateDepositDto updatedDepositDto);
	}
}
