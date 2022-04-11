﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalApp.Application.Dto.Posts
{
	public class CreatePostDto
	{
		public int Id { get; set; }
		public int CategoryId { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int DepositId { get; set; }
        public double Price { get; set; }
        public double? PricePerWeek { get; set; }
        public double? PricePerMonth { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime? AvailableTo { get; set; }
    }
}
