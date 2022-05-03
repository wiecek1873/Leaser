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

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user;
        }

        public async Task<User> AddUser(User newUser)
        {
            var result = await _userManager.CreateAsync(newUser, newUser.PasswordHash);

            if (!result.Succeeded)
                return null;

            return newUser;
        }

        public async Task UpdateUser(string userId, User updatedUser)
		{
            var userToUpdate = await _userManager.FindByIdAsync(userId);

            if(userToUpdate != null)
			{
                userToUpdate.Email = updatedUser.Email;
                userToUpdate.PasswordHash = updatedUser.PasswordHash;
                userToUpdate.PhoneNumber = updatedUser.PhoneNumber;
                userToUpdate.NickName = updatedUser.NickName;
                userToUpdate.Name = updatedUser.Name;
                userToUpdate.Surname = updatedUser.Surname;
			}

            await _userManager.UpdateAsync(userToUpdate);
		}
    }
}
