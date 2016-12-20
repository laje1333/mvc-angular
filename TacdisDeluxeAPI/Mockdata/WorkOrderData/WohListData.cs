using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.Mockdata.WorkOrderData
{
    public class WohListData
    {
        private static string separator = ",";

        public static string GetWohList(string search)
        {
            return "{\"woh\":[" + CreateWohLines() + "]}";
        }
        
        private static string CreateWohLines()
        {
            string result = "";
            List<string> listLine = new List<string>();

            foreach (var WO in WorkOrderDB.WorkOrders)
            {
                listLine.Add(CreateLine(WO));
            }
            result = string.Join(separator, listLine);
            return result;
        }

        private static string CreateLine(WorkOrderDB.WorkOrder WO)
        {
            WO.CalculateTotalCost();
            return "{\"WoNr\": \"" + WO.WoNr +
                    "\",\"RegNr\": \"" + WO.RegNr +
                    "\",\"Status\": \"" + WO.Status +
                    "\",\"VehDesc\": \"" + WO.VehDesc +
                    "\",\"CreatedDate\": \"" + WO.CreatedDate +
                    "\",\"MainPayer\":\"" + WO.MainPayer +
                    "\",\"RespBy\": \"" + WO.RespBy +
                    "\",\"TotCost\": \"" + WO.TotCost +
                    "\"}";
        }

        public static string GetWojList(string wohId)
        {
            return "{\"woj\":[" + CreateWojLines(wohId) + "]}";
        }

        private static string CreateWojLines(string wohId)
        {
            string result = "";
            List<string> listLine = new List<string>();
            var WojList = WorkOrderDB.GetWorkOrder(wohId).GetWoJList();
            foreach (WoJob woj in WojList)
            {
                listLine.Add(CreateLine(woj));
            }
            result = string.Join(separator, listLine);
            return result;
        }

        private static string CreateLine(WoJob woj)
        {
            woj.CalculateTotalCost();
            return "{\"WoJNr\": \"" + woj.WoJNr +
                    "\",\"Status\": \"" + woj.Status +
                    "\",\"TotCost\": \"" + woj.TotCost +
                    "\"}";
        }

        internal static string GetWjkList(string wohId, string wojId)
        {
            return "{\"wjk\":[" + CreateWjkLines(wohId, wojId) + "]}";
        }

        private static string CreateWjkLines(string wohId, string wojId)
        {
            string result = "";
            List<string> listLine = new List<string>();
            var WOJ_KitList = WorkOrderDB.GetWorkOrder(wohId).GetWoJList(wojId).GetWOJ_KitList();
            foreach (var WO in WOJ_KitList)
            {
                listLine.Add(CreateLine(WO));
            }
            result = string.Join(separator, listLine);
            return result;
        }

        private static string CreateLine(WoJobKit wjk)
        {
            wjk.CalculateTotalCost();
            return "{\"KitNr\": \"" + wjk.KitNr +
                    "\",\"KitType\": \"" + wjk.KitType +
                    "\",\"KitDesc\": \"" + wjk.KitDesc +
                    "\",\"Quantity\": \"" + wjk.Quantity +
                    "\",\"Price\": \"" + wjk.TotCost +
                    "\"}";
        }

        internal static string GetWjoList(string wohId, string wojId)
        {
            return "{\"wjo\":[" + CreateWjoLines(wohId, wojId) + "]}";
        }

        private static string CreateWjoLines(string wohId, string wojId)
        {
            string result = "";
            List<string> listLine = new List<string>();
            var WOJ_OpList = WorkOrderDB.GetWorkOrder(wohId).GetWoJList(wojId).GetWOJ_OPList();
            foreach (var wjo in WOJ_OpList)
            {
                listLine.Add(CreateLine(wjo));
            }
            result = string.Join(separator, listLine);
            return result;
        }
        
        private static string CreateLine(WoJobOP wjo)
        {
            wjo.CalculatePriceCost();
            return "{\"OPNr\": \"" + wjo.OPNr +
                    "\",\"OPDesc\": \"" + wjo.OPDesc +
                    "\",\"WorkTime\": \"" + wjo.WorkTime +
                    "\",\"Quantity\": \"" + wjo.Quantity +
                    "\",\"Price\": \"" + wjo.Price +
                    "\"}";
        }

        internal static string GetWjpList(string wohId, string wojId)
        {
            return "{\"wjp\":[" + CreateWjpLines(wohId, wojId) + "]}";
        }

        private static string CreateWjpLines(string wohId, string wojId)
        {
            string result = "";
            List<string> listLine = new List<string>();
            var WOJ_PartList = WorkOrderDB.GetWorkOrder(wohId).GetWoJList(wojId).GetWOJ_PartList();
            foreach (var wjp in WOJ_PartList)
            {
                listLine.Add(CreateLine(wjp));
            }
            result = string.Join(separator, listLine);
            return result;
        }

        private static string CreateLine(WoJobPart wjp)
        {
            wjp.CalculatePriceCost();
            return "{\"PartNr\": \"" + wjp.PartNr +
                    "\",\"PartDesc\": \"" + wjp.PartDesc +
                    "\",\"Quantity\": \"" + wjp.Quantity +
                    "\",\"Price\": \"" + wjp.Price +
                    "\"}";
        }
    }
}