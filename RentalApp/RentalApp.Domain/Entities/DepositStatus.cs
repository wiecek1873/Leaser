using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalApp.Domain.Entities
{
    public class DepositStatus
    {
        [Key]
        public int Id { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Deposit> Deposits { get; set; }
    }
}
