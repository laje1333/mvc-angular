using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.Models
{
    public class WorkshopInventoryItem
    {
        [Key]
        public int Id { get; set; }

        public int WorkshopId { get; set; }
        public int PartId { get; set; }
        public int Amount { get; set; }
    }
}