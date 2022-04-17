using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalApp.Domain.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public string Title  { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public int? DepositId { get; set; }

        [ForeignKey("DepositId")]
        public virtual Deposit Deposit { get; set; }

        public double Price { get; set; }

        public double? PricePerWeek { get; set; }

        public double? PricePerMonth { get; set; }

        public DateTime AvailableFrom { get; set; }

        public DateTime? AvailableTo { get; set; }
    }
}
