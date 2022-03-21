using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentalApp.Application.Dto;
using RentalApp.Application.Interfaces;
using RentalApp.Domain.Interfaces;

namespace RentalApp.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UsersService(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await _usersRepository.GetUsers();

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}
