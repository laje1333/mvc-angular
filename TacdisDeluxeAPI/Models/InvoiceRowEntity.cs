using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TacdisDeluxeAPI.Models
{
    [Table("InvoiceRow")]
    public class InvoiceRowEntity
    {
        [Key]
        public int Id { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public double UnitCost { get; set; }
        public int Quantity { get; set; }
        public double Vat { get; set; }
        public double InvoiceRowAmount { get; set; }

        [IgnoreDataMember]
        public InvoiceEntity Invoice { get; set; }
    }
}