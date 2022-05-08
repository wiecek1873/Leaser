using System.Collections.Generic;
using System.Threading.Tasks;
using RentalApp.Application.Dto.Payments;

namespace RentalApp.Application.Interfaces
{
	public interface IPaymentsService
	{
		Task<PaymentDto> GetPayment(int paymentId);

		Task<PaymentDto> CreatePayment(RequestPaymentDto newPaymentDto);

		Task UpdatePayment(int paymentId, RequestPaymentDto updatedPaymentDto);

		Task DeletePayment(int paymentId);
	}
}
