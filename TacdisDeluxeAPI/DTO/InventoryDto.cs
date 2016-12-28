using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TacdisDeluxeAPI.Models;

namespace TacdisDeluxeAPI.DTO
{
    public class InventoryDto
    {
        public int MainInventoryAmount { get; set; }
        public int WorkshopAmount { get; set; }
        public string Name { get; set; }
        
    }
}