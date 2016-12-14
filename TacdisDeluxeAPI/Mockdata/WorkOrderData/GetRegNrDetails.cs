using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.Mockdata.WorkOrderData
{
    public class GetRegNrDetails
    {
        public static string GetVehDesc(string RegNr)
        {
            string response = "";
            switch (RegNr)
            {
                case "HTP804":
                    response = "Volvo V70 II 5 dörrar Herrgårdsvagn 2,0F Flex LE Kinetic B4204S4 MTX75 Q2 085093  2009";
                    break;
                case "MFB412":
                    response = "Volvo V70 II 5 dörrar Herrgårdsvagn 1,6D DRIVe Momentum D4162T MMT6 233058  2012";
                    break;
                case "GMK765":
                    response = "Volvo S40 4 dörrar Sedan 2,0 Classic Momentum B4204S3 MTX75 577776  2012";
                    break;
                case "WRZ004":
                    response = "Volvo V70N 5 dörrar Herrgårdsvagn 2,4 140 Addition B5244S2 M56 513675  2005";
                    break;
                case "DSP793":
                    response = "Volvo V70 II 5 dörrar Herrgårdsvagn 1,6D DRIVe 119g Momentum D4164T MTX75 Q2 161006  2010";
                    break;
                default:
                    break;
            }
            return response;
        }
        
        public static string GetVehRegDate(string RegNr)
        {
            string response = "";
            switch (RegNr)
            {
                case "HTP804":
                    response = "2008-09-19";
                    break;
                case "MFB412":
                    response = "2011-12-19";
                    break;
                case "GMK765":
                    response = "2012-04-02";
                    break;
                case "WRZ004":
                    response = "2005-04-15";
                    break;
                case "DSP793":
                    response = "2010-04-23";
                    break;
                default:
                    break;
            }
            return response;
        }

        public static string GetOwner(string RegNr)
        {
            string response = "";
            switch (RegNr)
            {
                case "HTP804":
                    response = "Jimmy Karlsson";
                    break;
                case "MFB412":
                    response = "Magnus Lindqvist";
                    break;
                case "GMK765":
                    response = "Hannes Hedenskog";
                    break;
                case "WRZ004":
                    response = "Axels Bil AB";
                    break;
                case "DSP793":
                    response = "Magnus Wiberg";
                    break;
                default:
                    break;
            }
            return response;
        }

        public static string GetDriver(string RegNr)
        {
            string response = "";
            //response = GetOwner(RegNr);
            return response;
        }

        public static string GetPhoneNr(string RegNr)
        {
            string response = "";
            switch (RegNr)
            {
                case "HTP804":
                    response = "076 867 47 87";
                    break;
                case "MFB412":
                    response = "070 686 52 08";
                    break;
                case "GMK765":
                    response = "";
                    break;
                case "WRZ004":
                    response = "";
                    break;
                case "DSP793":
                    response = "070 182 17 31";
                    break;
                default:
                    break;
            }
            return response;
        }

        internal static string GetLastVisDate(string RegNr)
        {
            string response = "";
            switch (RegNr)
            {
                case "HTP804":
                    response = "2016-11-24";
                    break;
                case "MFB412":
                    response = "2016-11-15";
                    break;
                case "GMK765":
                    response = "2012-05-02";
                    break;
                case "WRZ004":
                    response = "";
                    break;
                case "DSP793":
                    response = "";
                    break;
                default:
                    break;
            }
            return response;
        }

        internal static string GetLastVisMilage(string RegNr)
        {
            string response = "";
            switch (RegNr)
            {
                case "HTP804":
                    response = "13131";
                    break;
                case "MFB412":
                    response = "22222";
                    break;
                case "GMK765":
                    response = "1368";
                    break;
                case "WRZ004":
                    response = "";
                    break;
                case "DSP793":
                    response = "";
                    break;
                default:
                    break;
            }
            return response;
        }
    }
}