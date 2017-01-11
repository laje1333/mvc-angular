using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TacdisDeluxeAPI.Models;

namespace TacdisDeluxeAPI.DTO
{
    public class WoStatusDto
    {
        public string wohId { get; set; }
        public DateTime plannedDate { get; set; }
        public bool isCheckedIn { get; set; }
        public DateTime checkedInDate { get; set; }
        public int currentMilage { get; set; }
        public int plannedMechID { get; set; }
    }
}