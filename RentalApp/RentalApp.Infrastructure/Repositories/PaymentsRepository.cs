using RentalApp.Domain.Interfaces;
using RentalApp.Domain.Entities;
using System.Threading.Tasks;
using RentalApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace RentalApp.Infrastructure.Repositories
{
	public class PaymentsRepository : IPaymentsRepository
	{
		private readonly RentalAppContext _rentalAppContext;

		public PaymentsRepository(RentalAppContext rentalAppContext)
		{
			_rentalAppContext = rentalAppContext;
		}

		public async Task<Payment> GetPayment(int paymentId)
		{
			var payment = await _rentalAppContext.Payments.SingleOrDefaultAsync(p => p.Id == paymentId);

			return payment;
		}

		public async Task<Payment> AddPayment(Payment newPayment)
		{
			_rentalAppContext.Payments.Add(newPayment);
			await _rentalAppContext.SaveChangesAsync();

			return newPayment;
		}

		public async Task UpdatePayment(int paymentId, Payment updatedPayment)
		{
			var paymentToUpdate = await _rentalAppContext.Payments.SingleOrDefaultAsync(p => p.Id == paymentId);

			if(paymentToUpdate != null)
			{
				paymentToUpdate.Bank = updatedPayment.Bank;
				paymentToUpdate.CardNumber = updatedPayment.CardNumber;
				paymentToUpdate.ExpirationDate = updatedPayment.ExpirationDate;
				paymentToUpdate.CVV = updatedPayment.CVV;
			}

			await _rentalAppContext.SaveChangesAsync();
		}

		public async Task DeletePayment(int paymentId)
		{
			var paymentToDelete = await _rentalAppContext.Payments.SingleOrDefaultAsync(p => p.Id == paymentId);

			if (paymentToDelete != null)
				_rentalAppContext.Payments.Remove(paymentToDelete);

			await _rentalAppContext.SaveChangesAsync();
		}
	}
}
