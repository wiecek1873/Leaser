using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RentalApp.Domain.Entities
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public string Bank { get; set; }

        public string CardNumber { get; set; }

        public string ExpirationDate { get; set; }

        public string CVV { get; set; }
    }
}
