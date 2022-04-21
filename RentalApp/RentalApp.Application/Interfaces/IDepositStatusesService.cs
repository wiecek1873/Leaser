﻿using System.Threading.Tasks;
using RentalApp.Application.Dto.DepositStatuses;

namespace RentalApp.Application.Interfaces
{
	public interface IDepositStatusesService
	{
		Task<DepositStatusDto> GetDepositStatus(int depositStatusId);
		Task<DepositStatusDto> CreateDepositStatus(RequestDepositStatusDto newDepositStatusDto);
		public Task UpdateDepositStatus(int depositStatusId, RequestDepositStatusDto updatedDepositStatusDto);
	}
}