using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace RentalApp.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string NickName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public double Points { get; set; }

        public int? AddressId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

        public virtual ICollection<Deposit> Deposits { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<UserRate> UserRates { get; set; }
    }
}
