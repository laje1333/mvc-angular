using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TacdisDeluxeAPI.Models;

namespace TacdisDeluxeAPI.Mockdata.WorkOrderData
{
    public class WohListData
    {
        private static string separator = ",";

        //WOH
        internal static string GetWohList(IOrderedQueryable<Models.WorkOrderEntity> woList)
        {
            return "{\"woh\":[" + CreateWohLines(woList) + "]}";
        }

        private static string CreateWohLines(IOrderedQueryable<Models.WorkOrderEntity> woList)
        {
            string result = "";
            List<string> listLine = new List<string>();

            foreach (var WO in woList)
            {
                listLine.Add(CreateLine(WO));
            }
            result = string.Join(separator, listLine);
            return result;
        }
        
        private static string CreateLine(Models.WorkOrderEntity WO)
        {
            WO.UpdateTotCost();
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

        //WOJ
        public static string GetWojList(WorkOrderEntity WO)
        {
            return "{\"woj\":[" + CreateWojLines(WO) + "]}";
        }

        private static string CreateWojLines(WorkOrderEntity WO)
        {
            string result = "";
            List<string> listLine = new List<string>();
            foreach (WoJobEntity woj in WO.WOJ_List)
            {
                listLine.Add(CreateLine(woj));
            }
            result = string.Join(separator, listLine);
            return result;
        }

        private static string CreateLine(WoJobEntity woj)
        {
            woj.UpdateTotCost();
            return "{\"WoJNr\": \"" + woj.WoJNr +
                    "\",\"Status\": \"" + woj.Status +
                    "\",\"TotCost\": \"" + woj.TotCost +
                    "\"}";
        }

        //WJK
        internal static string GetWjkList(ICollection<WoKitsEntity> wjkList)
        {
            return "{\"wjk\":[" + CreateWjkLines(wjkList) + "]}";
        }

        private static string CreateWjkLines(ICollection<WoKitsEntity> wjkList)
        {
            string result = "";
            List<string> listLine = new List<string>();
            foreach (var wjk in wjkList)
            {
                listLine.Add(CreateLine(wjk));
            }
            result = string.Join(separator, listLine);
            return result;
        }

        private static string CreateLine(WoKitsEntity wjk)
        {
            wjk.UpdateTotCost();
            return "{\"KitId\": \"" + wjk.Id +
                    "\",\"KitNr\": \"" + wjk.WJKCode +
                    "\",\"KitType\": \"" + wjk.KitType +
                    "\",\"KitDesc\": \"" + wjk.KitDesc +
                    "\",\"Quantity\": \"" + wjk.Quantity +
                    "\",\"Price\": \"" + wjk.TotCost +
                    "\"}";
        }

        //WJO
        internal static string GetWjoList(ICollection<WoOpEntitys> wjoList)
        {
            return "{\"wjo\":[" + CreateWjoLines(wjoList) + "]}";
        }

        private static string CreateWjoLines(ICollection<WoOpEntitys> wjoList)
        {
            string result = "";
            List<string> listLine = new List<string>();
            foreach (var wjo in wjoList)
            {
                listLine.Add(CreateLine(wjo));
            }
            result = string.Join(separator, listLine);
            return result;
        }
        
        private static string CreateLine(WoOpEntitys wjo)
        {
            return "{\"OPId\": \"" + wjo.Id +
                    "\",\"OPNr\": \"" + wjo.OPNr +
                    "\",\"OPDesc\": \"" + wjo.OPDesc +
                    "\",\"WorkTime\": \"" + wjo.WorkTime +
                    "\",\"Quantity\": \"" + wjo.Quantity +
                    "\",\"Price\": \"" + wjo.Price +
                    "\"}";
        }

        //WJP
        internal static string GetWjpList(ICollection<PartEntity> wjpList)
        {
            return "{\"wjp\":[" + CreateWjpLines(wjpList) + "]}";
        }

        private static string CreateWjpLines(ICollection<PartEntity> wjpList)
        {
            string result = "";
            List<string> listLine = new List<string>();
            foreach (var wjp in wjpList)
            {
                listLine.Add(CreateLine(wjp));
            }
            result = string.Join(separator, listLine);
            return result;
        }

        private static string CreateLine(PartEntity wjp)
        {
            return "{\"PartId\": \"" + wjp.Id +
                    "\",\"PartNr\": \"" + wjp.ItemId +
                    "\",\"PartDesc\": \"" + wjp.ItemDesc +
                    "\",\"Quantity\": \"" + (1).ToString() +
                    "\",\"Price\": \"" + wjp.ItemPrice +
                    "\"}";
        }


    }
}