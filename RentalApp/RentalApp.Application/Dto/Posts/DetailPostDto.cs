using System;

namespace RentalApp.Application.Dto.Posts
{
	public class DetailPostDto
	{
		public int Id { get; set; }

		public int CategoryId { get; set; }

		public Guid UserId { get; set; }

		public string UserNickName {get; set;}

		public string PhoneNumber { get; set; }

		public double Rating { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public double Price { get; set; }

		public double DepositValue { get; set; }

		public double? PricePerWeek { get; set; }

		public double? PricePerMonth { get; set; }

		public DateTime AvailableFrom { get; set; }

		public DateTime? AvailableTo { get; set; }

		public string Country { get; set; }

		public string City { get; set; }

		public string Street { get; set; }

		public string BuildingNo { get; set; }

		public string ApartmentNo { get; set; }

		public string PostalCode { get; set; }
	}
}
