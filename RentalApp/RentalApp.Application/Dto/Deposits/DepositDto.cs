using System;

namespace RentalApp.Application.Dto.Deposits
{
	public class DepositDto
	{
		public int Id { get; set; }

		public int Value { get; set; }

		public Guid PayerId { get; set; }

		public int StatusId { get; set; }
	}
}
