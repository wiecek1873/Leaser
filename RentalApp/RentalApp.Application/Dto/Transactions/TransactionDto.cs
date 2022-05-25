using System;


namespace RentalApp.Application.Dto.Transactions
{
    public class TransactionDto
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        public Guid PayerId { get; set; }

        public double Price { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }
}
