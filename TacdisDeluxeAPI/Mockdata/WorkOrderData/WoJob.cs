using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.Mockdata.WorkOrderData
{

    public class WoJob
    {
        public WoJob(string newWoHJobID)
        {
            WoJNr = newWoHJobID;
            FixedPrice = "";
            VatPerc = "";
        }

        List<WoJobKit> WOJ_KitList = new List<WoJobKit>();
        List<WoJobOP> WOJ_OPList = new List<WoJobOP>();
        List<WoJobPart> WOJ_PartList = new List<WoJobPart>();

        public string WoJNr { get; set; }
        public string Status { get; set; }
        public string TotCost { get; set; }
        public string JobDoneDate { get; set; }

        public string PayerCustNr { get; set; }
        public string Alias { get; set; }
        public string AddressType { get; set; }
        public string AddressFull { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Contact { get; set; }
        public string PaymentMethod { get; set; }

        public string FixedPrice { get; set; }
        public string VatPerc { get; set; }

        public string RefNo { get; set; }
        public string RefNoExtra { get; set; }
        public string ProfCentreID { get; set; }
        public string ProfCentreName { get; set; }

        public string CalculateTotalCost()
        {
            TotCost = (0).ToString();
            //Calc
            foreach (var kit in WOJ_KitList)
            {
                TotCost = (Int32.Parse(TotCost) + Int32.Parse(kit.CalculateTotalCost())).ToString();
            }
            foreach (var op in WOJ_OPList)
            {
                TotCost = (Int32.Parse(TotCost) + Int32.Parse(op.CalculatePriceCost())).ToString();
            }
            foreach (var part in WOJ_PartList)
            {
                TotCost = (Int32.Parse(TotCost) + Int32.Parse(part.CalculatePriceCost())).ToString();
            }
            //IF Fixedprice
            return TotCost;
        }
    }
}