using System.Threading.Tasks;
using RentalApp.Domain.Entities;

namespace RentalApp.Domain.Interfaces
{
	public interface IPaymentsRepository
	{
		Task<Payment> GetPayment(int paymentId);
		Task<Payment> AddPayment(Payment newPayment);
		Task UpdatePayment(int paymentId, Payment updatedPayment);
		Task DeletePayment(int paymentId);
	}
}
