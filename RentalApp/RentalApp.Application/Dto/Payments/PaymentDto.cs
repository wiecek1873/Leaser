using System;

namespace RentalApp.Application.Dto.Payments
{
	public class PaymentDto
	{
		public int Id { get; set; }

		public Guid UserId { get; set; }

		public string Bank { get; set; }

		public string CardNumber { get; set; }

		public string ExpirationDate { get; set; }

		public string CVV { get; set; }
	}
}
