using System;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RentalApp.Application.Interfaces;
using RentalApp.Domain.Interfaces;
using RentalApp.Domain.Entities;
using RentalApp.Application.Dto.Users;
using RentalApp.Application.Exceptions;

namespace RentalApp.Application.Services
{
	public class UsersService : IUsersService
	{
		private readonly IUsersRepository _usersRepository;
		private readonly IUserRatesRepository _userRatesRepository;
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;

		public UsersService(IUsersRepository usersRepository, IUserRatesRepository userRatesRepository, UserManager<User> userManager, IMapper mapper)
		{
			_usersRepository = usersRepository;
			_userRatesRepository = userRatesRepository;
			_userManager = userManager;
			_mapper = mapper;
		}

		public async Task<UserDto> GetUser(string userId)
		{
			if (!Guid.TryParse(userId, out var userGuid))
				throw new BadRequestException("User id should contain 32 digits with 4 dashes (xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx).");

			var user = await _usersRepository.GetUser(userId);

			if (user == null)
				throw new NotFoundException("User does not exist.");

			var userRates = await _userRatesRepository.GetUserRatesByUserId(userGuid);
			var rates = new List<int>();

			foreach (var rate in userRates)
				rates.Add(rate.Rate);

			var userDto = _mapper.Map<UserDto>(user);
			userDto.Rating = CalculateAverageUserRate(rates.ToArray());

			return userDto;
		}

		public async Task<UserDto> GetUserByEmail(string email)
		{
			if (string.IsNullOrEmpty(email))
				throw new BadRequestException("Email can not be empty");

			var user = await _usersRepository.GetUserByEmail(email);

			if (user == null)
				throw new NotFoundException("User does not exist.");

			var userRates = await _userRatesRepository.GetUserRatesByUserId(user.Id);
			var rates = new List<int>();

			foreach (var rate in userRates)
				rates.Add(rate.Rate);

			var userDto = _mapper.Map<UserDto>(user);
			userDto.Rating = CalculateAverageUserRate(rates.ToArray());


			return userDto;
		}

		public async Task<UserDto> CreateUser(CreateUserDto newUserDto)
		{
			var user = await _userManager.FindByEmailAsync(newUserDto.Email);

			if (user != null)
				throw new ConflictException("User with the same email already exists!");

			var newUser = _mapper.Map<User>(newUserDto);

			if (newUser == null)
				throw new ConflictException("User creation failed! Please check user details and try again.");

			var result = await _usersRepository.AddUser(newUser);

			if (result == null)
				throw new ConflictException("Credentials are wrong. Check if password has eight letters, upper letter and special sign.");

			return _mapper.Map<UserDto>(newUser);
		}

		public async Task UpdateUser(string userId, UpdateUserDto updatedUserDto)
		{
			if (!Guid.TryParse(userId, out var userGuid))
				throw new BadRequestException("User id should contain 32 digits with 4 dashes (xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx).");

			var userToUpdate = await _usersRepository.GetUser(userId);

			if (userToUpdate == null)
				throw new NotFoundException("User with this id does not exist.");

			userToUpdate = _mapper.Map<User>(updatedUserDto);

			var result = await _usersRepository.UpdateUser(userId, userToUpdate, updatedUserDto.OldPassword);

			if (!result)
				throw new ConflictException("Update failed. Check if password has eight letters, upper letter and special sign or old password is correct.");
		}

		public async Task<UserDto> AddPoints(string userId, double points)
		{
			if (points < 0)
				throw new BadRequestException("Can't add negative number of points");

			if (!Guid.TryParse(userId, out var userGuid))
				throw new BadRequestException("User id should contain 32 digits with 4 dashes (xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx).");

			var userToUpdate = await _usersRepository.GetUser(userId);

			if (userToUpdate == null)
				throw new NotFoundException("User with this id does not exist.");

			var result = await _usersRepository.AddPoints(userId, points);

			return _mapper.Map<UserDto>(result);
		}

		private double CalculateAverageUserRate(int[] rates)
		{
			if (rates.Length == 0)
				return 0;

			var averageRate = Queryable.Average(rates.AsQueryable());

			return averageRate;
		}
	}
}
