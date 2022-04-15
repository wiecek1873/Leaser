using System.ComponentModel.DataAnnotations;

namespace RentalApp.Application.Dto.Deposits
{
	public class CreateDepositDto
	{
		[Required(ErrorMessage = "Value is required.")]
		public int Value { get; set; }
	}
}
