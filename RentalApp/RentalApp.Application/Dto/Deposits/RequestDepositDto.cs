using System.ComponentModel.DataAnnotations;
using RentalApp.Application.Dto.DepositStatuses;

namespace RentalApp.Application.Dto.Deposits
{
	class RequestDepositDto
	{
		[Required(ErrorMessage = "Value is required.")]
		public int Value { get; set; }
	}
}
