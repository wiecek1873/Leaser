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

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<DepositStatus> DepositStatuses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
