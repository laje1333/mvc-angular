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
        private const string Separator = ",";

        //WOH
        internal static string GetWohList(IOrderedQueryable<WorkOrderEntity> woList)
        {
            return "{\"woh\":[" + CreateWohLines(woList) + "]}";
        }

        private static string CreateWohLines(IEnumerable<WorkOrderEntity> woList)
        {
            var result = "";
            var listLine = woList.Select(WO => CreateLine(WO)).ToList();

            result = string.Join(Separator, listLine);
            return result;
        }

        private static string CreateLine(WorkOrderEntity wo)
        {
            wo.UpdateTotCost();
            string custNr = "", empNr = "";
            if (wo.MainPayer != null)
            {
                custNr = wo.MainPayer.CustomerNumber.ToString();
            }

            if (wo.RespBy != null)
            {
                empNr = wo.RespBy.EmployeeNumber.ToString();
            }

            return "{\"WoNr\": \"" + wo.WoNr +
                    "\",\"RegNr\": \"" + wo.RegNr +
                    "\",\"Status\": \"" + wo.Status +
                    "\",\"VehDesc\": \"" + wo.VehDesc.Replace("\n", " ") +
                    "\",\"CreatedDate\": \"" + wo.CreatedDate +
                    "\",\"MainPayer\":\"" + custNr +
                    "\",\"RespBy\": \"" + empNr +
                    "\",\"TotCost\": \"" + wo.TotCost +
                    "\"}";
        }

        //WOJ
        public static string GetWojList(WorkOrderEntity wo)
        {
            return "{\"woj\":[" + CreateWojLines(wo) + "]}";
        }

        private static string CreateWojLines(WorkOrderEntity wo)
        {
            var result = "";
            var listLine = wo.WOJ_List.Select(CreateLine).ToList();
            result = string.Join(Separator, listLine);
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

        private static string CreateWjkLines(IEnumerable<WoKitsEntity> wjkList)
        {
            var result = "";
            var listLine = wjkList.Select(CreateLine).ToList();
            result = string.Join(Separator, listLine);
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

        private static string CreateWjoLines(IEnumerable<WoOpEntitys> wjoList)
        {
            var result = "";
            var listLine = wjoList.Select(CreateLine).ToList();
            result = string.Join(Separator, listLine);
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
            var result = "";
            var listLine = new List<string>();

            foreach (var wjp in woj.WOJ_PartList)
            {
                var idAndAmountEntity = woj.WOJ_PartList_Ids.FirstOrDefault(p => p.Id == wjp.Id);
                if (idAndAmountEntity == null) continue;
                var amount = idAndAmountEntity.Amount;

                listLine.Add(CreateLine(wjp, amount));
            }
            result = string.Join(Separator, listLine);
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