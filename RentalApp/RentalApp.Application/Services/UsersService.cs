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
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UsersService(IUsersRepository usersRepository, UserManager<User> userManager, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateUser(CreateUserDto newUserDto)
        {
            var user = await _userManager.FindByEmailAsync(newUserDto.Email);

            if (user != null)
                throw new ConflictException("User with the same email already exists!");

            var newUser = _mapper.Map<User>(newUserDto);

            if (newUser == null)
                throw new ConflictException("User creation failed! Please check user details and try again.");

            await _usersRepository.AddUser(newUser);

            return _mapper.Map<UserDto>(newUser);
        }
    }
}
