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
    [Table("Part")]
    public class PartEntity
    {
        public PartEntity()
        {
            Sales = new List<SaleEntity>();
        }

        [Key]
        public int Id { get; set; }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public string ItemDesc { get; set; }
        public double VAT { get; set; }
        public bool SpecFsg { get; set; }

        [IgnoreDataMember]
        public ICollection<SaleEntity> Sales { get; set; }
        public ICollection<WoJobEntity> WoJob { get; set; }
        public ICollection<WoKitsEntity> WoKits { get; set; }
    }
}
