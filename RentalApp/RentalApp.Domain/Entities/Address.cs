﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalApp.Domain.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int BuildingNo { get; set; }

        public int? ApartmentNo { get; set; }

        public string PostalCode { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
