using RentalApp.Application.Validations;
using System.ComponentModel.DataAnnotations;

namespace RentalApp.Application.Dto.Users
{
    public class UpdateUserDto
    {
        public string NickName { get; set; }

        [Required(ErrorMessage = "Name of the user is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname of the user is required.")]
        public string Surname { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email of the user is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Old Password of the user is required.")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "New Password of the user is required.")]
        public string NewPassword { get; set; }

        [PhoneNumberValidation(ErrorMessage = "Wrong Phone Number.")]
        [Required(ErrorMessage = "PhoneNumber of the user is required.")]
        public string PhoneNumber { get; set; }
    }
}
