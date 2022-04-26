using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RentalApp.Application.Interfaces;
using RentalApp.Domain.Interfaces;
using RentalApp.Domain.Entities;
using RentalApp.Application.Dto.Users;
using RentalApp.Application.Exceptions;
using System;

namespace RentalApp.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UsersService(IUsersRepository usersRepository, UserManager<User> userManager, IMapper mapper)
        {
            _usersRepository = usersRepository;
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

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new BadRequestException("Email can not be empty");

            var user = await _usersRepository.GetUserByEmail(email);

            if (user == null)
                throw new NotFoundException("User does not exist.");

            return _mapper.Map<UserDto>(user);
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
    }
}
