using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.Models
{
    public class WorkshopInventory
    {

        public WorkshopInventory()
        {
            InventoryItems = new List<WorkshopInventoryItem>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public int WorkshopId { get; set; }
        public virtual ICollection<WorkshopInventoryItem> InventoryItems { get; set; }

    }
}