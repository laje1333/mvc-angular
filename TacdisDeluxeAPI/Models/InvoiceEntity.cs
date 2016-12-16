using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacdisDeluxeAPI.Models
{
    public class InvoiceEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string InvoiceState { get; set; }
        public PayerEntity Payer { get; set; }

//        [Index(IsUnique = true)]


    }
}
