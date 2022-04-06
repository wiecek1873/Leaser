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
        public Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
