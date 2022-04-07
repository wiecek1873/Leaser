using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalApp.Domain.Entities
{
    public class Deposit
    {
        [Key]
        public int Id { get; set; }

        public int Value { get; set; }

        public Guid? PayerId { get; set; }

        [ForeignKey("PayerId")]
        public virtual User User { get; set; }

        public int StatusId { get; set; }

        [ForeignKey("StatusId")]
        public virtual DepositStatus DepositStatus { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
