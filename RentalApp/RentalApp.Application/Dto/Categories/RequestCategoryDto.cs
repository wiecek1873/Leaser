using System.ComponentModel.DataAnnotations;

namespace RentalApp.Application.Dto.Categories
{
	public class RequestCategoryDto
	{
		[Required(ErrorMessage = "Category name is required.")]
		public string CategoryName { get; set; }
	}
}
