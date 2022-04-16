using AutoMapper;
using System.Threading.Tasks;
using RentalApp.Application.Exceptions;
using RentalApp.Application.Dto.DepositStatuses;
using RentalApp.Application.Interfaces;
using RentalApp.Domain.Interfaces;
using RentalApp.Domain.Entities;

namespace RentalApp.Application.Services
{
	public class DepositStatusesService : IDepositStatusesService
	{
		private readonly IDepositStatusesRepository _depositStatusesRepository;
		private readonly IMapper _mapper;

		public DepositStatusesService(IDepositStatusesRepository depositStatusesRepository, IMapper mapper)
		{
			_depositStatusesRepository = depositStatusesRepository;
			_mapper = mapper;
		}

		public async Task<DepositStatusDto> GetDepositStatus(int depositStatusId)
		{
			var depositStatus = await _depositStatusesRepository.GetDepositStatus(depositStatusId);

			if (depositStatus == null)
				throw new NotFoundException("Deposit status with this id does not exist.");

			return _mapper.Map<DepositStatusDto>(depositStatus);
		}

		public async Task<DepositStatusDto> CreateDepositStatus(CreateDepositStatusDto newDepositStatusDto)
		{
			var depositStatusToAdd = _mapper.Map<DepositStatus>(newDepositStatusDto);

			await _depositStatusesRepository.AddDepositStatus(depositStatusToAdd);

			return _mapper.Map<DepositStatusDto>(depositStatusToAdd);
		}

		public async Task UpdateDepositStatus(int depositStatusId, CreateDepositStatusDto updatedDepositStatusDto)
		{
			var depositStatusToUpdate = await _depositStatusesRepository.GetDepositStatus(depositStatusId);

			if (depositStatusToUpdate == null)
				throw new NotFoundException("Deposit status with this id does not exist.");

			depositStatusToUpdate = _mapper.Map<DepositStatus>(updatedDepositStatusDto);

			await _depositStatusesRepository.UpdateDepositStatus(depositStatusId, depositStatusToUpdate);
		}
	}
}
