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
            WOJ_PartList_Ids = new List<IdAndAmountEntity>();
        }

        public void UpdateTotCost()
        {
            TotCost = 0;
            foreach (var item in WOJ_PartList)
            {
                TotCost += item.ItemPrice * WOJ_PartList_Ids.Where(p => p.Id == item.ItemId).FirstOrDefault().Amount;
            }
            foreach (var item in WOJ_OPList)
            {
                TotCost += item.Price;
            }
            foreach (var item in WOJ_KitList)
            {
                item.UpdateTotCost();
                TotCost += item.TotCost;
            }
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
        public string PayerName { get; set; }
        public string FirstName { get; set; }
        public string Contact { get; set; }
        public string PaymentMethod { get; set; }

        public double FixedPrice { get; set; }
        public double VatPerc { get; set; }

        public string RefNo { get; set; }
        public string RefNoExtra { get; set; }
        public string ProfCentreID { get; set; }
        public string ProfCentreName { get; set; }

        public virtual ICollection<WoKitsEntity> WOJ_KitList { get; set; }
        public virtual ICollection<WoOpEntitys> WOJ_OPList { get; set; }
        public virtual ICollection<PartEntity> WOJ_PartList { get; set; }

        public virtual ICollection<IdAndAmountEntity> WOJ_PartList_Ids { get; set; }

        [IgnoreDataMember]
        public WorkOrderEntity WorkOrder { get; set; }
    }
}