using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacdisDeluxeAPI.DTO
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public int InvoiceNumber { get; set; }
        public string InvoiceState { get; set; }
        public string DueDate { get; set; }
        public string InvoiceDate { get; set; }
        public double InvoiceAmount { get; set; }
        public string DebitCredit { get; set; }
        public double Vat { get; set; }
        public double AmountPaid { get; set; }
        public int WoNumber { get; set; }
        public string JobNumber { get; set; }
        public string RegNumber { get; set; }
        public ICollection<InvoiceRowDto> InvoiceRows { get; set; }
        public SalesmanDto Salesman { get; set; }
        public PayerDto Payer { get; set; }
    }
}
