﻿using System;
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
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<List<UserRateDto>> GetUserRates(string userRatedId)
        {
            if (!Guid.TryParse(userRatedId, out var userRatedGuid))
                throw new BadRequestException("User id should contain 32 digits with 4 dashes (xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx).");

            var userRates = await _userRatesRepository.GetUserRates(userRatedGuid);

            return _mapper.Map<List<UserRateDto>>(userRates);
        }

        public async Task<UserRateDto> GetUserRate(int userRateId)
        {
            var userRate = await _userRatesRepository.GetUserRate(userRateId);

            if (userRate == null)
                throw new NotFoundException("User Rate with this id does not exist.");

            return _mapper.Map<UserRateDto>(userRate);
        }

        public async Task<UserRateDto> CreateUserRate(string userRaterId, CreateUserRateDto newUserRateDto)
        {
            var userRater =  await _usersRepository.GetUser(userRaterId);

            if (userRater == null)
                throw new NotFoundException("User Rater with this id does not exist!");

            var userRated = await _usersRepository.GetUser(newUserRateDto.RatedUserId.ToString());

            if (userRated == null)
                throw new NotFoundException("User Rated with this id does not exist!");

            if (newUserRateDto.Rate < 1 || newUserRateDto.Rate > 5)
                throw new BadRequestException("You can add rate from 1 to 5.");

            if (Guid.Parse(userRaterId) == newUserRateDto.RatedUserId)
                throw new ConflictException("You can not rate yourself!");

            var checkUserRate = await _userRatesRepository.GetUserRateByUsersRelation(Guid.Parse(userRaterId), newUserRateDto.RatedUserId);
            if (checkUserRate != null)
                throw new MethodNotAllowedException("You can not rate the same user again.");

            var userRateToAdd = _mapper.Map<UserRate>(newUserRateDto);
            userRateToAdd.RaterUserId = userRater.Id;

            await _userRatesRepository.AddUserRate(userRateToAdd);

            return _mapper.Map<UserRateDto>(userRateToAdd);
        }

        public async Task UpdateUserRate(string userId, int userRateId, UpdateUserRateDto updatedUserRateDto)
        {
            var userRateToUpdate = await _userRatesRepository.GetUserRate(userRateId);

            if (userRateToUpdate == null)
                throw new NotFoundException("User Rate with this id does not exist.");

            if (updatedUserRateDto.Rate < 1 || updatedUserRateDto.Rate > 5)
                throw new BadRequestException("You can add rate from 1 to 5.");

            if (userRateToUpdate.RaterUserId != Guid.Parse(userId))
                throw new MethodNotAllowedException("You can not update rates from diffrent users.");

            userRateToUpdate = _mapper.Map<UserRate>(updatedUserRateDto);

            await _userRatesRepository.UpdateUserRate(userRateId, userRateToUpdate);
        }

        public async Task DeleteUserRate(string userId, int userRateId)
        {
            var userRateToDelete = await _userRatesRepository.GetUserRate(userRateId);

            if (userRateToDelete == null)
                throw new NotFoundException("User Rate with this id does not exist.");

            if (userRateToDelete.RaterUserId != Guid.Parse(userId))
                throw new MethodNotAllowedException("You can not delete rates from diffrent users.");

            await _userRatesRepository.DeleteUserRate(userRateId);
        }
    }
}
