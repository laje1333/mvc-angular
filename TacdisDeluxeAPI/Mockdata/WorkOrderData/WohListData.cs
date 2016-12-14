using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.Mockdata.WorkOrderData
{
    public class WohListData
    {
        private static string separator = ",";
        //class WohLine
        //{
        //    public WohLine(string woNr,
        //        string regNr,
        //        string status,
        //        string vehDesc,
        //        string createdDate,
        //        string mainPayer,
        //        string respBy,
        //        string totCost
        //        )
        //    {
        //        WoNr = woNr;
        //        RegNr = regNr;
        //        Status = status;
        //        VehDesc = vehDesc;
        //        CreatedDate = createdDate;
        //        MainPayer = mainPayer;
        //        RespBy = respBy;
        //        TotCost = totCost;
        //    }
        //    public string WoNr { get; set; }
        //    public string RegNr { get; set; }
        //    public string Status { get; set; }
        //    public string VehDesc { get; set; }
        //    public string CreatedDate { get; set; }
        //    public string MainPayer { get; set; }
        //    public string RespBy { get; set; }
        //    public string TotCost { get; set; }
        //}

        //static List<WohLine> wohLines = new List<WohLine>();


        public static string GetWohList(string search)
        {
            return "{\"woh\":[" + CreateLines() + "]}";
        }


        private static string CreateLines()
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
    }
}