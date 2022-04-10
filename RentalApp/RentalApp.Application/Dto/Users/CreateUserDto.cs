using System.ComponentModel.DataAnnotations;
using RentalApp.Application.Validations;

namespace RentalApp.Application.Dto.Users
{
    public class CreateUserDto
    {
        public string NickName { get; set; }

        [Required(ErrorMessage = "Name of the user is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname of the user is required.")]
        public string Surname { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email of the user is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password of the user is required.")]
        public string Password { get; set; }

        [PhoneNumberValidation(ErrorMessage = "Wrong Phone Number.")]
        [Required(ErrorMessage = "PhoneNumber of the user is required.")]
        public string PhoneNumber { get; set; }
    }
}
