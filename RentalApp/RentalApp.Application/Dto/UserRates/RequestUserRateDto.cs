using System;
using System.ComponentModel.DataAnnotations;

namespace RentalApp.Application.Dto.UserRates
{
    public class RequestUserRateDto
    {
        [Required(ErrorMessage = "Rated User id is required.")]
        public Guid RatedUserId { get; set; }

        [Required(ErrorMessage = "Rate is required.")]
        public int Rate { get; set; }

        public string Comment { get; set; }
    }
}
