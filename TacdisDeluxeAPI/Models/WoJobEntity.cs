using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TacdisDeluxeAPI.Models
{
    [Table("WorkOrderJobs")]
    public class WoJobEntity
    {
        public WoJobEntity()
        {
            WOJ_KitList = new List<WoKitsEntity>();
            WOJ_OPList = new List<WoOpEntitys>();
            WOJ_PartList = new List<PartEntity>();
        }

        [Key]
        public int ID { get; set; }
        public int WoJNr { get; set; }
        public string Status { get; set; }
        public double TotCost { get; set; }
        public DateTime JobDoneDate { get; set; }

        public int PayerCustNr { get; set; }
        public string Alias { get; set; }
        public string AddressType { get; set; }
        public string AddressFull { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Contact { get; set; }
        public string PaymentMethod { get; set; }

        public double FixedPrice { get; set; }
        public double VatPerc { get; set; }

        public string RefNo { get; set; }
        public string RefNoExtra { get; set; }
        public string ProfCentreID { get; set; }
        public string ProfCentreName { get; set; }

        public ICollection<WoKitsEntity> WOJ_KitList;
        public ICollection<WoOpEntitys> WOJ_OPList;
        public ICollection<PartEntity> WOJ_PartList;
        
        [IgnoreDataMember]
        public WorkOrderEntity WorkOrder { get; set; }
    }
}