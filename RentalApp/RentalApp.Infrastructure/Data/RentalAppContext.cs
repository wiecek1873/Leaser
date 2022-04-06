using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RentalApp.Domain.Entities;

namespace RentalApp.Infrastructure.Data
{
    public class RentalAppContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public RentalAppContext(DbContextOptions<RentalAppContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
