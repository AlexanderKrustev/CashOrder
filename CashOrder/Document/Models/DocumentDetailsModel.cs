namespace CashOrder.Document.Models
{
    public class DocumentDetailsModel
    {
        public int DocumentId { get; set; }

        public string Receiver { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public int FirmId { get; set; }

        public string FirmName { get; set; }

    }
}
