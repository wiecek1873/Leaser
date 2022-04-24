using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalApp.Application.Dto.UserRates
{
    public class UserRateDto
    {
        public int Id { get; set; }

        public Guid RaterUserId { get; set; }

        public Guid RatedUserId { get; set; }

        public int Rate { get; set; }

        public string Comment { get; set; }
    }
}
