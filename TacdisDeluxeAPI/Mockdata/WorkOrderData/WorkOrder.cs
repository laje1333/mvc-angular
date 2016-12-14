﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.Mockdata.WorkOrderData
{
    public static class WorkOrderDB
    {
        public static List<WorkOrder> WorkOrders = new List<WorkOrder>();

        public static string CreateNewWorkOrder()
        {
            string newWoHID = (WorkOrders.Count + 1272150).ToString();
            WorkOrders.Add(new WorkOrder(newWoHID));
            return newWoHID;
        }

        public static WorkOrder GetWorkOrder(string WoNr)
        {
            foreach (var WO in WorkOrders)
            {
                if (WO.WoNr == WoNr)
                {
                    return WO;
                }
            }
            return null;
        }


        public class WorkOrder
        {
            public WorkOrder(string woNr)
            {
                WoNr = woNr;
                Status = "New";
                CreatedDate = System.DateTime.Now.ToString();
            }

            public string CreateNewWorkOrderJob()
            {
                string newWoHJobID = (WorkOrders.Count).ToString();
                WOJ_List.Add(new WoJob(newWoHJobID));
                return newWoHJobID;
            }

            List<WoJob> WOJ_List = new List<WoJob>();

            public string WoNr { get; set; }
            public string Status { get; set; }

            public string RegNr { get; set; }
            public string VehDesc { get; set; }
            public string VehRegDate { get; set; }
            public string VehOwner { get; set; }
            public string VehDriver { get; set; }
            public string VehPhoneNr { get; set; }
            public string VehLastVisDate { get; set; }
            public string VehLastVisMil { get; set; }

            public string CurrentMilage { get; set; }
            public string PlannedMechID { get; set; }
            public string PlannedMechName { get; set; }

            public string CreatedDate { get; set; }
            public string PlannedDate { get; set; }
            public string CheckedInDate { get; set; }

            public string MainPayer { get; set; }
            public string RespBy { get; set; }
            public string TotCost { get; set; }

            public string CalculateTotalCost()
            {
                TotCost = (0).ToString();
                foreach (var job in WOJ_List)
                {
                    TotCost = (Int32.Parse(TotCost) + Int32.Parse(job.CalculateTotalCost())).ToString();
                }
                return TotCost;
            }
            public void RegNrChanged(string regNr)
            {
                RegNr = regNr;
                VehDesc = GetRegNrDetails.GetVehDesc(regNr);
                VehRegDate = GetRegNrDetails.GetVehRegDate(regNr);
                VehOwner = GetRegNrDetails.GetOwner(regNr);
                VehDriver = GetRegNrDetails.GetDriver(regNr);
                VehPhoneNr = GetRegNrDetails.GetPhoneNr(regNr);
                VehLastVisDate = GetRegNrDetails.GetLastVisDate(regNr);
                VehLastVisMil = GetRegNrDetails.GetLastVisMilage(regNr);
            }
        }
    }
}