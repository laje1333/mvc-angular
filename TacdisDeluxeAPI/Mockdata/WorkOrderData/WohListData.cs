using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.Mockdata.WorkOrderData
{
    public class WohListData
    {
        private static string separator = ",";
        class WohLine
        {
            public WohLine(string woNr,
                string regNr,
                string status,
                string vehDesc,
                string createdDate,
                string mainPayer,
                string respBy,
                string totCost
                )
            {
                WoNr = woNr;
                RegNr = regNr;
                Status = status;
                VehDesc = vehDesc;
                CreatedDate = createdDate;
                MainPayer = mainPayer;
                RespBy = respBy;
                TotCost = totCost;
            }
            public string WoNr { get; set; }
            public string RegNr { get; set; }
            public string Status { get; set; }
            public string VehDesc { get; set; }
            public string CreatedDate { get; set; }
            public string MainPayer { get; set; }
            public string RespBy { get; set; }
            public string TotCost { get; set; }
        }

        static List<WohLine> wohLines = new List<WohLine>();


        public static string GetWohList(string search)
        {
            if (wohLines.Count == 0)
            {
                //wohLines.Add(new WohLine("woNr1", "regNr", "status", "vehDesc", "createdDate", "mainPayer", "respBy", "totCost"));
                //wohLines.Add(new WohLine("woNr2", "regNr", "status", "vehDesc", "createdDate", "mainPayer", "respBy", "totCost"));
                //wohLines.Add(new WohLine("woNr3", "regNr", "status", "vehDesc", "createdDate", "mainPayer", "respBy", "totCost"));
                //wohLines.Add(new WohLine("woNr4", "regNr", "status", "vehDesc", "createdDate", "mainPayer", "respBy", "totCost"));
            }

            return "{\"woh\":[" + CreateLines(wohLines) + "]}";
        }


        private static string CreateLines(List<WohLine> wohLines)
        {
            string result = "";
            List<string> listLine = new List<string>();

            foreach (var wohLine in wohLines)
            {
                listLine.Add(CreateLine(wohLine));
            }
            result = string.Join(separator, listLine);
            return result;
        }

        private static string CreateLine(WohLine wohLine)
        {
            return "{\"WoNr\": \"" + wohLine.WoNr +
                    "\",\"RegNr\": \"" + wohLine.RegNr +
                    "\",\"Status\": \"" + wohLine.Status +
                    "\",\"VehDesc\": \"" + wohLine.VehDesc +
                    "\",\"CreatedDate\": \"" + wohLine.CreatedDate +
                    "\",\"MainPayer\":\"" + wohLine.MainPayer +
                    "\",\"RespBy\": \"" + wohLine.RespBy +
                    "\",\"TotCost\": \"" + wohLine.TotCost +
                    "\"}";
        }

        internal static void AddNewWOH(string woh)
        {
            wohLines.Add(new WohLine(woh, "", "New", "", System.DateTime.Now.ToString(), "", "", ""));
        }

        internal static void SetCurrentCar(string woh, string regnr, string vehDesc)
        {
            foreach (WohLine wohLine in wohLines)
            {
                if (wohLine.WoNr == woh)
                {
                    wohLine.RegNr = regnr;
                    wohLine.VehDesc = vehDesc;
                    break;
                }
            }
        }
    }
}