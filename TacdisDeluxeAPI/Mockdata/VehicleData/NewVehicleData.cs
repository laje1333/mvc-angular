using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.Mockdata.VehicleData
{
    public class NewVehicleData
    {
        public List<String> years  = new List<String>();
        public List<String> models = new List<String>();


        public string getModelAttr()
        {
            string result = "";

            //year append
            for (int i = 0; i < years.Count; i++)
            {
                if (i < years.Count - 1)
                {
                    result += years[i] + ",";
                }
                else
                {
                    result += years[i];
                }

            }
            result += "=";
            //model append
            for (int i = 0; i < models.Count; i++)
            {
                if (i < years.Count - 1)
                {
                    result += models[i] + ",";
                }
                else
                {
                    result += models[i];
                }
            }
            return result;
        }



    }
}