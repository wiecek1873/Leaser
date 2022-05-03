namespace RentalApp.Application.Dto.Users
{
    public class RequestUserDto
    {
        public string NickName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public int? AddressId { get; set; }
    }
}
