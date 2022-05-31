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

        [Required(ErrorMessage = "Old Password of the user is required.")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "New Password of the user is required.")]
        public string NewPassword { get; set; }
    }
}
