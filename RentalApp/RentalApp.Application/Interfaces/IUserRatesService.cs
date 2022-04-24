using System.Threading.Tasks;
using RentalApp.Application.Dto.UserRates;

namespace RentalApp.Application.Interfaces
{
    public interface IUserRatesService
    {
        Task<UserRateDto> CreateUserRate(string userRatedId, RequestUserRateDto newUserRateDto);
    }
}
