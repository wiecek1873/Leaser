using Microsoft.AspNetCore.Identity;
using System;

namespace RentalApp.Domain.Entities
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public User() { }

        public User (string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
