using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TacdisDeluxeAPI.DTO;
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
            string custNr = "", empNr = "";
            if (WO.MainPayer != null)
            {
                custNr = WO.MainPayer.CustomerNumber.ToString();
            }

            if (WO.RespBy != null)
            {
                empNr = WO.RespBy.EmployeeNumber.ToString();
            }

            return "{\"WoNr\": \"" + WO.WoNr +
                    "\",\"RegNr\": \"" + WO.RegNr +
                    "\",\"Status\": \"" + WO.Status +
                    "\",\"VehDesc\": \"" + WO.VehDesc +
                    "\",\"CreatedDate\": \"" + WO.CreatedDate +
                    "\",\"MainPayer\":\"" + custNr +
                    "\",\"RespBy\": \"" + empNr +
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
        internal static string GetWjpList(WoJobEntity woj)
        {
            return "{\"wjp\":[" + CreateWjpLines(woj) + "]}";
        }

        private static string CreateWjpLines(WoJobEntity woj)
        {
            string result = "";
            List<string> listLine = new List<string>();
            //var wojDto = Mapper.Map<WoJobEntity, WoJobDto>(new WoJobEntity());

            foreach (var wjp in woj.WOJ_PartList)
            {
                double amount = woj.WOJ_PartList_Ids.Where(p => p.Id == wjp.Id).FirstOrDefault().Amount;

                listLine.Add(CreateLine(wjp, amount));
            }
            result = string.Join(separator, listLine);
            return result;
        }

        private static string CreateLine(PartEntity wjp, double amount)
        {
            return "{\"PartId\": \"" + wjp.Id +
                    "\",\"PartNr\": \"" + wjp.ItemId +
                    "\",\"PartDesc\": \"" + wjp.ItemDesc +
                    "\",\"Quantity\": \"" + amount +
                    "\",\"Price\": \"" + wjp.ItemPrice * amount +
                    "\"}";
        }


    }
}