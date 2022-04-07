using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalApp.Domain.Entities
{
    public class UserRate
    {
        [Key]
        public int Id { get; set; }

        public Guid RaterUserId { get; set; }

        [ForeignKey("RaterUserId")]
        public virtual User User { get; set; }

        public Guid RatedUserId { get; set; }

        public int Rate { get; set; }

        public string Comment { get; set; }
    }
}
