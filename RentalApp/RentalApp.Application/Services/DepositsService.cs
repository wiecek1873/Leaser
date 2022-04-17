using AutoMapper;
using System.Threading.Tasks;
using RentalApp.Application.Exceptions;
using RentalApp.Application.Dto.Deposits;
using RentalApp.Application.Interfaces;
using RentalApp.Domain.Interfaces;
using RentalApp.Domain.Entities;

namespace RentalApp.Application.Services
{
	public class DepositsService : IDepositsService
	{
		private readonly IDepositsRepository _depositsRepository;
		private readonly IDepositStatusesRepository _depositStatusesRepository;
		private readonly IMapper _mapper;

		public DepositsService(IDepositsRepository depositsRepository, IDepositStatusesRepository depositStatusesRepository,IMapper mapper)
		{
			_depositsRepository = depositsRepository;
			_depositStatusesRepository = depositStatusesRepository;
			_mapper = mapper;
		}

		public async Task<DepositDto> GetDeposit(int depositId)
		{
			var deposit = await _depositsRepository.GetDeposit(depositId);

			if (deposit == null)
				throw new NotFoundException("Deposit with this id does not exist.");

			return _mapper.Map<DepositDto>(deposit);
		}

		public async Task<DepositDto> CreateDeposit(RequestDepositDto newDepositDto)
		{
			var depositToAdd = _mapper.Map<Deposit>(newDepositDto);

			await _depositsRepository.AddDeposit(depositToAdd);

			return _mapper.Map<DepositDto>(depositToAdd);
		}

		// jak robisz update nie uzywaj nazwenictwa => create, jesli dto post u put sa takie same mozna uzyc tej samej klasy
		public async Task UpdateDeposit(int depositId, RequestDepositDto updatedDepositDto)
		{
			var depositToUpdate = await _depositsRepository.GetDeposit(depositId);

			if (depositToUpdate == null)
				throw new NotFoundException("Deposit with this id does not exist.");

			depositToUpdate = _mapper.Map<Deposit>(updatedDepositDto);

			await _depositsRepository.UpdateDeposit(depositId, depositToUpdate);
		}
	}
}
