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
            newUser.Points = 100;
            var result = await _userManager.CreateAsync(newUser, newUser.PasswordHash);

            if (!result.Succeeded)
                return null;

            return newUser;
        }

        public async Task<bool> UpdateUser(string userId, User updatedUser, string oldPassword)
		{
            var userToUpdate = await _userManager.FindByIdAsync(userId);

            if (userToUpdate != null)
			{
                userToUpdate.SecurityStamp = Guid.NewGuid().ToString("D");
                userToUpdate.Email = updatedUser.Email;
                userToUpdate.PhoneNumber = updatedUser.PhoneNumber;
                userToUpdate.NickName = updatedUser.NickName;
                userToUpdate.Name = updatedUser.Name;
                userToUpdate.Surname = updatedUser.Surname;
                userToUpdate.UserName = updatedUser.UserName;
                userToUpdate.NormalizedEmail = updatedUser.Email.ToUpper();
                userToUpdate.NormalizedUserName = updatedUser.UserName.ToUpper();
                var result = await _userManager.ChangePasswordAsync(userToUpdate, oldPassword, updatedUser.PasswordHash);

                if (!result.Succeeded)
                    return false;
            }

            await _userManager.UpdateAsync(userToUpdate);

            return true;
		}
    }
}
