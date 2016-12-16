using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace TacdisDeluxeAPI.Models
{
    [Table("Invoice")]
    public class InvoiceEntity
    {
        public InvoiceEntity()
        {
            InvoiceRows = new List<InvoiceRowEntity>();
        }

        [Key]
        public int Id { get; set; }
        [Index(IsUnique = true)]
        public int InvoiceNumber { get; set; }
        [Required]
        public string InvoiceState { get; set; }
        public string DueDate { get; set; }
        public string InvoiceDate { get; set; }
        public double InvoiceAmount { get; set; }
        public string DebitCredit { get; set; }
        public double Vat { get; set; }
        public double AmountPaid { get; set; }
        public virtual ICollection<InvoiceRowEntity> InvoiceRows { get; set; }
        public SalesmanEntity Salesman { get; set; }
        public int WoNumber { get; set; }
        public string JobNumber { get; set; }
        public PayerEntity Payer { get; set; }
        public string RegNumber { get; set; }

    }
}
