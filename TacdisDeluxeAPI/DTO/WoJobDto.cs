using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TacdisDeluxeAPI.Models;

namespace TacdisDeluxeAPI.DTO
{
    public class WoJobDtoExtended : WoJobDto
    {
        public string wohid { get; set; }
        public string wojid { get; set; }
    }

    public class WoJobDto
    {
        public WoJobDto()
        {

        }

        public WoJobDto(WoJobEntity wojEnt)
        {
            ID = wojEnt.ID;
            WoJNr = wojEnt.WoJNr;
            Status = wojEnt.Status;
            TotCost = wojEnt.TotCost;
            JobDoneDate = wojEnt.JobDoneDate;

            PayerCustNr = wojEnt.PayerCustNr;
            Alias = wojEnt.Alias;
            AddressType = wojEnt.AddressType;
            AddressFull = wojEnt.AddressFull;
            PayerName = wojEnt.PayerName;
            FirstName = wojEnt.FirstName;
            Contact = wojEnt.Contact;
            PaymentMethod = wojEnt.PaymentMethod;

            FixedPrice = wojEnt.FixedPrice;
            VatPerc = wojEnt.VatPerc;

            RefNo = wojEnt.RefNo;
            RefNoExtra = wojEnt.RefNoExtra;
            ProfCentreID = wojEnt.ProfCentreID;
            ProfCentreName = wojEnt.ProfCentreName;
        }

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

        public int[] WOJ_KitList_Ids { get; set; }
        public int[] WOJ_OPList_Ids { get; set; }
        public ICollection<IdAndAmountEntity> WOJ_PartList_Ids { get; set; }
    }
}