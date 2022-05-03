using System.ComponentModel.DataAnnotations;

namespace RentalApp.Application.Dto.Categories
{
	public class RequestCategoryDto
	{
		[Required(ErrorMessage = "Category name is required.")]
		public string CategoryName { get; set; }
		[Required(ErrorMessage ="Category image URL is required.")]
		public string ImageURL { get; set; }
	}
}
