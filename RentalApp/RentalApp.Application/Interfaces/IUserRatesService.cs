using System.Threading.Tasks;
using RentalApp.Application.Dto.UserRates;

namespace RentalApp.Application.Interfaces
{
    public interface IUserRatesService
    {
        Task<UserRateDto> GetUserRate(int userRateId);

        Task<UserRateDto> CreateUserRate(string userRaterId, CreateUserRateDto newUserRateDto);

        Task UpdateUserRate(string userId, int userRateId, UpdateUserRateDto updatedUserRateDto);

        Task DeleteUserRate(int userRateId);
    }
}
