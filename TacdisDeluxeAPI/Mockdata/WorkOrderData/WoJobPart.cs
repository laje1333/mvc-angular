using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TacdisDeluxeAPI.Mockdata.WorkOrderData
{
    public class WoJobPart
    {
        public WoJobPart(string wjpcode)
        {
            // TODO: add stuff
            Price = (0).ToString();
            PartNr = wjpcode;
        }
        
        public string PartNr { get; set; }
        public string PartDesc { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }

        public string CalculatePriceCost()
        {
            Price = (0).ToString();
            //Calc
            return Price;
        }
    }
}
