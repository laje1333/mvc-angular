﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TacdisDeluxeAPI.Mockdata.WorkOrderData
{
    public class WoJobOP
    {
        public WoJobOP()
        {
            Price = (0).ToString();
        }
        
        public string OPNr { get; set; }
        public string OPDesc { get; set; }
        public string Quantity { get; set; }
        public string WorkTime { get; set; }
        public string Price { get; set; }

        public string CalculatePriceCost()
        {
            Price = (0).ToString();
            //Calc
            return Price;
        }
    }
}
