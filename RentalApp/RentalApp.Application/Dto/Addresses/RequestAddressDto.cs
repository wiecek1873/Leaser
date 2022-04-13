using RentalApp.Application.Validations;
using System.ComponentModel.DataAnnotations;

namespace RentalApp.Application.Dto.Addresses
{
    public class RequestAddressDto
    {
        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Street is required.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Building No is required.")]
        public string BuildingNo { get; set; }

        public string ApartmentNo { get; set; }

        [PostalCodeValidation(ErrorMessage = "Wrong Postal Code.")]
        [Required(ErrorMessage = "Postal Code is required.")]
        public string PostalCode { get; set; }
    }
}
