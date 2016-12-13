using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.Mockdata.WorkOrderData
{
    public class NewWoJobData
    {
        static int count;

        internal static string GetNewWOJ()
        {
            count++;
            return count.ToString();
        }

        internal static void ResetWoJID()
        {
            count = 1;
        }

        internal static string GetCurrentWOJ()
        {
            return count.ToString();
        }
    }
}