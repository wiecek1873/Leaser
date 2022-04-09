using System.Threading.Tasks;
using RentalApp.Application.Dto.Users;


namespace RentalApp.Application.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetToken(LoginUserDto loginUserDto);
    }
}
