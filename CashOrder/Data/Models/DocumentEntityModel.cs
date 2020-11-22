namespace CashOrder.Data.Models
{
    using System;

    public class DocumentEntityModel
    {
        public int Id { get; set; }

        public String Receiver { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public int FirmId { get; set; }

        public FirmEntityModel Firm { get; set; }
    }
}
