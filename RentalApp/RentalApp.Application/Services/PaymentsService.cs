using AutoMapper;
using System.Threading.Tasks;
using RentalApp.Application.Exceptions;
using RentalApp.Application.Interfaces;
using RentalApp.Domain.Interfaces;
using RentalApp.Domain.Entities;
using RentalApp.Application.Dto.Payments;

namespace RentalApp.Application.Services
{
	public class PaymentsService : IPaymentsService
	{
		private readonly IPaymentsRepository _paymentsRepository;
		private readonly IMapper _mapper;

		public PaymentsService(IPaymentsRepository paymentsRepository, IMapper mapper)
		{
			_paymentsRepository = paymentsRepository;
			_mapper = mapper;
		}

		public async Task<PaymentDto> GetPayment(int paymentId)
		{
			var payment = await _paymentsRepository.GetPayment(paymentId);

			if (payment == null)
				throw new NotFoundException("Payment with this id does not exist.");

			return _mapper.Map<PaymentDto>(payment);
		}

		public async Task<PaymentDto> CreatePayment(RequestPaymentDto newPaymentDto)
		{
			var paymentToAdd = _mapper.Map<Payment>(newPaymentDto);

			await _paymentsRepository.AddPayment(paymentToAdd);

			return _mapper.Map<PaymentDto>(paymentToAdd);
		}

		public async Task UpdatePayment(int paymentId, RequestPaymentDto updatedPaymentDto)
		{
			var paymentToUpdate = await _paymentsRepository.GetPayment(paymentId);

			if (paymentToUpdate == null)
				throw new NotFoundException("Payment with this id does not exist.");

			paymentToUpdate = _mapper.Map<Payment>(updatedPaymentDto);

			await _paymentsRepository.UpdatePayment(paymentId, paymentToUpdate);
		}

		public async Task DeletePayment(int paymentId)
		{
			var paymentToDelete = await _paymentsRepository.GetPayment(paymentId);

			if (paymentToDelete == null)
				throw new NotFoundException("Payment with this id does not exist.");

			await _paymentsRepository.DeletePayment(paymentId);
		}
	}
}
