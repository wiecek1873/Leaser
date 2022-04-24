using System;
using System.ComponentModel.DataAnnotations;

namespace RentalApp.Application.Dto.Posts
{
	public class RequestPostDto
	{
		[Required(ErrorMessage = "Title is required.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Description is required.")]
		public string Description { get; set; }

		public int? DepositId { get; set; }

		[Required(ErrorMessage = "Price is required.")]
		public double Price { get; set; }

		public double? PricePerWeek { get; set; }

		public double? PricePerMonth { get; set; }

		[Required(ErrorMessage = "Avaiable from date is required.")]
		public DateTime AvailableFrom { get; set; }

		public DateTime? AvailableTo { get; set; }
	}
}
