using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TacdisDeluxeAPI.Models
{
    public class SalesAddonEntity
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double VAT { get; set; }

        [IgnoreDataMember]
        public ICollection<SaleEntity> Sales { get; internal set; }
    }
}
