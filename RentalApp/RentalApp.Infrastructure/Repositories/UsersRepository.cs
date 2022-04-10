using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RentalApp.Domain.Entities;
using RentalApp.Domain.Interfaces;

namespace RentalApp.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UserManager<User> _userManager;

        public UsersRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> GetUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return user;
        }

        public async Task<User> AddUser(User newUser)
        {
            var result = await _userManager.CreateAsync(newUser, newUser.PasswordHash);

            if (!result.Succeeded)
                return null;

            return newUser;
        }
    }
}
