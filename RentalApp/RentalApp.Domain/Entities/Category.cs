using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalApp.Domain.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
