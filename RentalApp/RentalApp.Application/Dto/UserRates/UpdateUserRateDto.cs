using System.ComponentModel.DataAnnotations;

namespace RentalApp.Application.Dto.UserRates
{
    public class UpdateUserRateDto
    {
        [Required(ErrorMessage = "Rate is required.")]
        public int Rate { get; set; }

        public string Comment { get; set; }
    }
}
