namespace CashOrder.Document.Models
{
    public class CreateDocumentModel
    {
        public string Receiver { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public int FirmId { get; set; }
    }
}
