using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.Models
{
    [Table("WoKits")]
    public class WoKitsEntity
    {
        public WoKitsEntity()
        {
            WOJ_OPList = new List<WoOpEntitys>();
            WOJ_PartList = new List<PartEntity>();
        }
        
        ICollection<WoOpEntitys> WOJ_OPList;
        ICollection<PartEntity> WOJ_PartList;

        [Key]
        public int KitNr { get; set; }
        public string KitType { get; set; }
        public string KitDesc { get; set; }
        public double Quantity { get; set; }
        public double TotCost { get; set; }
    }
}