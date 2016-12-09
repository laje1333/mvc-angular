using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.Mockdata.VehicleData
{
    public static class NewVehicleDataHash
    {
        private static Dictionary<String, NewVehicleData> vehicleHash = new Dictionary<String, NewVehicleData>();

        public static void initialize()
        {
            NewVehicleData volvo = new NewVehicleData();
            volvo.years.Add("2010");
            volvo.years.Add("2011");
            volvo.years.Add("2012");
            volvo.models.Add("XC-90");
            volvo.models.Add("V-70");
            volvo.models.Add("240");

            vehicleHash.Add("Volvo", volvo);

            NewVehicleData ford = new NewVehicleData();
            ford.years.Add("2013");
            ford.years.Add("2014");
            ford.years.Add("2015");
            ford.models.Add("Mondeo");
            ford.models.Add("Mustang");

            vehicleHash.Add("Ford", ford);
        }

        public static NewVehicleData getValue(string key)
        {
            return vehicleHash[key];
        }
    }
}