using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TacdisDeluxeAPI.Models
{
    [Table("Payer")]
    public class PayerEntity
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool Trusted { get; set; }
        [Index(IsUnique = true)]
        public int CustomerNumber { get; set; }
        public string StreeatAddress { get; set; }

        public string ZipCity { get; set; }

        public string Country { get; set; }

        public string PhoneNr { get; set; }

        public ICollection<SaleEntity> Sales { get; internal set; }

    }
}
