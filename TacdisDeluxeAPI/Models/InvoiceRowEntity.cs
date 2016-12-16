using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TacdisDeluxeAPI.Models
{
    [Table("InvoiceRow")]
    public class InvoiceRowEntity
    {
        [Key]
        public int Id { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public string UnitCost { get; set; }
        public string Quantity { get; set; }
        public string Vat { get; set; }
        public string InvoiceRowAmount { get; set; }

    }
}