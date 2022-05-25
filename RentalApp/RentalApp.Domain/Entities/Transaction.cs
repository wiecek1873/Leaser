using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalApp.Domain.Entities
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PostId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        [Required]
        public Guid PayerId { get; set; }

        public double Price { get; set; }

        public TransactionStatus Status { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }



    public enum TransactionStatus
    {
        Borrowed,
        Delivered
    }
}
