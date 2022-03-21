using RentalApp.Domain.Entities;
using RentalApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalApp.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private static readonly ISet<User> _users = new HashSet<User>()
        {
            new User ("Robert", "Lewanodowski"),
            new User ("Kamil", "Glik"),
            new User ("Grzegorz", "Krychowiak")
        };

        public async Task<IEnumerable<User>> GetUsers()
        {
            return _users;
        }
    }
}
