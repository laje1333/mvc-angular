using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TacdisDeluxeAPI.Mockdata.WorkOrderData
{
    class WoJobKit
    {
        public WoJobKit()
        {
            TotCost = (0).ToString();
        }

        List<WoJobOP> WOJ_OPList = new List<WoJobOP>();
        List<WoJobPart> WOJ_PartList = new List<WoJobPart>();

        public string KitNr { get; set; }
        public string KitType { get; set; }
        public string KitDesc { get; set; }
        public string Quantity { get; set; }
        public string TotCost { get; set; }

        public string CalculateTotalCost()
        {
            TotCost = (0).ToString();
            foreach (var op in WOJ_OPList)
            {
                TotCost = (Int32.Parse(TotCost) + Int32.Parse(op.CalculatePriceCost())).ToString();
            }
            foreach (var part in WOJ_PartList)
            {
                TotCost = (Int32.Parse(TotCost) + Int32.Parse(part.CalculatePriceCost())).ToString();
            }
            return TotCost;
        }
    }
}
