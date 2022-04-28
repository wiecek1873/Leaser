using System;
using System.ComponentModel.DataAnnotations;

namespace RentalApp.Application.Dto.Payments
{
	public class RequestPaymentDto
	{
		[Required(ErrorMessage = "User id is required.")]
		public Guid UserId { get; set; }

		[Required(ErrorMessage = "Bank is required.")]
		public string Bank { get; set; }

		[Required(ErrorMessage = "Card number is required.")]
		public string CardNumber { get; set; }

		[Required(ErrorMessage = "Expiration date is required.")]
		public string ExpirationDate { get; set; }

		[Required(ErrorMessage = "CVV is required.")]
		public string CVV { get; set; }
	}
}
