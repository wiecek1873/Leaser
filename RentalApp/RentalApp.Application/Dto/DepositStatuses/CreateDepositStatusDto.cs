using System.ComponentModel.DataAnnotations;

namespace RentalApp.Application.Dto.DepositStatuses
{
	public class CreateDepositStatusDto
	{
		[Required(ErrorMessage = "Status is required.")]
		public string Status { get; set; }
		[Required(ErrorMessage = "Description is required.")]
		public string Description { get; set; }
	}
}
