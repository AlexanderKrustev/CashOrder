namespace CashOrder.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class FirmEntityModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Address { get; set; }

        [Required]
        [MaxLength(11)]
        [MinLength(9)]
        public string Vat { get; set; }


    }
}
