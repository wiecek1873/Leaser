using System;
using RentalApp.Application.Dto.Deposits;
using System.ComponentModel.DataAnnotations;

namespace RentalApp.Application.Dto.Posts
{
	public class RequestPostDto
	{
		//remove this 
		public string UserId { get; set; }

		[Required(ErrorMessage = "Category is required.")]
		public int CategoryId { get; set; }

		[Required(ErrorMessage = "Title is required.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Description is required.")]
		public string Description { get; set; }

		[Required(ErrorMessage = "Deposit value is required.")]
		public RequestDepositDto RequestDepositDto { get; set; }

		[Required(ErrorMessage = "Price is required.")]
		public double Price { get; set; }

		public double? PricePerWeek { get; set; }

		public double? PricePerMonth { get; set; }

		[Required(ErrorMessage = "Avaiable from date is required.")]
		public DateTime AvailableFrom { get; set; }

		public DateTime? AvailableTo { get; set; }

		[Required(ErrorMessage = "Image is required.")]
		public CreatePostImageDto CreatePostImageDto { get; set; }
	}
}
