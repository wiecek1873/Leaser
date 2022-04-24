using System.Threading.Tasks;
using RentalApp.Application.Dto.UserRates;

namespace RentalApp.Application.Interfaces
{
    public interface IUserRatesService
    {
        Task<UserRateDto> GetUserRate(int userRateId);
        Task<UserRateDto> CreateUserRate(string userRaterId, RequestUserRateDto newUserRateDto);
    }
}
