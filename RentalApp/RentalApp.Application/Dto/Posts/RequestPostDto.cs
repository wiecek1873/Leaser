using System;
using RentalApp.Application.Dto.Deposits;
using System.ComponentModel.DataAnnotations;

namespace RentalApp.Application.Dto.Posts
{
	public class RequestPostDto
	{
		public string UserId { get; set; }
		public int CategoryId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public RequestDepositDto RequestDepositDto { get; set; }
		public double Price { get; set; }
		public double? PricePerWeek { get; set; }
		public double? PricePerMonth { get; set; }
		public DateTime AvailableFrom { get; set; }
		public DateTime? AvailableTo { get; set; }
		public CreatePostImageDto CreatePostImageDto { get; set; }
	}
}
