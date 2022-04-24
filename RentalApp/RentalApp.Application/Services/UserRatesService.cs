using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using RentalApp.Domain.Entities;
using RentalApp.Application.Dto.UserRates;
using RentalApp.Application.Interfaces;
using RentalApp.Domain.Interfaces;
using RentalApp.Application.Exceptions;

namespace RentalApp.Application.Services
{
    public class UserRatesService : IUserRatesService
    {
        private readonly IUserRatesRepository _userRatesRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UserRatesService(IUserRatesRepository userRatesRepository, IUsersRepository usersRepository, IMapper mapper)
        {
            _userRatesRepository = userRatesRepository;
            _userRatesRepository = userRatesRepository;
            _mapper = mapper;
        }

        public async Task<UserRateDto> CreateUserRate(string userRaterId, RequestUserRateDto newUserRateDto)
        {
            var userRater =  await _usersRepository.GetUser(userRaterId);

            if (userRater == null)
                throw new NotFoundException("User Rater with this id does not exist!");

            var userRated = await _usersRepository.GetUser(newUserRateDto.RatedUserId.ToString());

            if (userRated == null)
                throw new NotFoundException("User Rated with this id does not exist!");

            var userRateToAdd = _mapper.Map<UserRate>(newUserRateDto);
            userRateToAdd.RaterUserId = userRater.Id;

            await _userRatesRepository.AddUserRate(userRateToAdd);

            return _mapper.Map<UserRateDto>(userRateToAdd);
        }
    }
}
