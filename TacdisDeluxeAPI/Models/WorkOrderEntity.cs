using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.Models
{
    [Table("WorkOrder")]
    public class WorkOrderEntity
    {

        public WorkOrderEntity()
        {
            WOJ_List = new List<WoJobEntity>();
        }
        public void UpdateTotCost()
        {
            TotCost = 0;
            foreach (var item in WOJ_List)
            {
                item.UpdateTotCost();
                TotCost += item.TotCost;
            }
        }

        [Key]
        public int WoNr { get; set; }
        public string Status { get; set; }

        public string RegNr { get; set; }
        public string VehDesc { get; set; }
        public DateTime VehRegDate { get; set; }
        public string VehOwner { get; set; }
        public string VehDriver { get; set; }
        public string VehPhoneNr { get; set; }
        public DateTime VehLastVisDate { get; set; }
        public string VehLastVisMil { get; set; }

        public bool isCheckedIn { get; set; }
        public double CurrentMilage { get; set; }
        public int PlannedMechID { get; set; }
        public string PlannedMechName { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime PlannedDate { get; set; }
        public DateTime CheckedInDate { get; set; }

        public virtual PayerEntity MainPayer { get; set; }
        public virtual SalesmanEntity RespBy { get; set; }
        public double TotCost { get; set; }

        public virtual ICollection<WoJobEntity> WOJ_List { get; set; }

    }
}