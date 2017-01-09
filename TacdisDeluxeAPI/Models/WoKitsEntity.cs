using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TacdisDeluxeAPI.Models
{
    [Table("WorkOrderKits")]
    public class WoKitsEntity
    {
        public WoKitsEntity(string wjkCode)
        {
            WJKCode = int.Parse(wjkCode);
            WOJ_OPList = new List<WoOpEntitys>();
            WOJ_PartList = new List<PartEntity>();
        }

        public virtual ICollection<WoOpEntitys> WOJ_OPList { get; set; }
        public virtual ICollection<PartEntity> WOJ_PartList { get; set; }

        [Key]
        public int Id { get; set; }
        public int WJKCode { get; set; }
        public string KitType { get; set; }
        public string KitDesc { get; set; }
        public double Quantity { get; set; }
        public double TotCost { get; set; }
        
        [IgnoreDataMember]
        public WoJobEntity WoJob { get; set; }
    }
}