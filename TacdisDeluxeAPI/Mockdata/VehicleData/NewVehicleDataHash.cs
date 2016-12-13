using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.Mockdata.VehicleData
{
    public static class NewVehicleDataHash
    {
        private static Dictionary<String, NewVehicleData> vehicleHash = new Dictionary<String, NewVehicleData>();
        public static string currentBrand = "";

        public static void initialize()
        {

            //Volvo
            ModelYear v2011 = new ModelYear("2011");

            Model xc90 = new Model("XC-90");
            xc90.addEngineDescription("V6 hybrid");
            xc90.addEngineGroup("Group-V6");
            xc90.addFuelType("Diesel");
            xc90.addFuelType("Petrol");
            xc90.addTransmissionType("Automatic");
            xc90.addTransmissionType("Manual");
            xc90.addTransmissionGroup("Group-Transmission-defaults");
            xc90.addTransmissionDescription("Default transmission");
            xc90.addPaintType("White");
            xc90.addPaintType("Black");
            xc90.addPaintGroup("Paint-group-default");
            xc90.addPaintDescription("Matte powdered-painted");
            xc90.addPaintDescription("Clear");
            xc90.addInteriorMaterial("Leather");
            xc90.addInteriorDescriptions("Matte leather");
            xc90.addInteriorDescriptions("Clear leather");
            xc90.addInteriorColor("Brown");
            xc90.addInteriorColor("White");
            xc90.addInteriorColor("Gray");
            v2011.addModel(xc90);

            Model v70 = new Model("V-70");
            v70.addEngineDescription("V5 default");
            v70.addEngineGroup("Group-V5");
            v70.addFuelType("Petrol");
            v70.addFuelType("Diesel");
            v70.addTransmissionType("Manual");
            v70.addTransmissionGroup("Group-Transmission-defaults");
            v70.addTransmissionDescription("Default transmission");
            v70.addPaintType("White");
            v70.addPaintGroup("Paint-group-default");
            v70.addPaintDescription("Matte powdered-painted");
            v70.addPaintDescription("Clear");
            v70.addInteriorMaterial("Leather");
            v70.addInteriorDescriptions("Matte leather");
            v70.addInteriorDescriptions("Clear leather");
            v70.addInteriorColor("Brown");
            v70.addInteriorColor("White");
            v70.addInteriorColor("Gray");
            v2011.addModel(v70);

            Model s60 = new Model("S-60");
            s60.addEngineDescription("V6 default");
            s60.addEngineGroup("Group-V6");
            s60.addFuelType("Diesel");
            s60.addFuelType("Petrol");
            s60.addTransmissionType("Automatic");
            s60.addTransmissionType("Manual");
            s60.addTransmissionGroup("Group-Transmission-defaults");
            s60.addTransmissionDescription("Default transmission");
            s60.addPaintType("Black");
            s60.addPaintGroup("Paint-group-default");
            s60.addPaintDescription("Matte powdered-painted");
            s60.addPaintDescription("Clear");
            s60.addInteriorMaterial("Leather");
            s60.addInteriorDescriptions("Matte leather");
            s60.addInteriorDescriptions("Clear leather");
            s60.addInteriorColor("Brown");
            s60.addInteriorColor("White");
            s60.addInteriorColor("Gray");
            v2011.addModel(s60);

            Brand volvo = new Brand("Volvo");
            volvo.addModelYear(v2011);

            NewVehicleData volvoData = new NewVehicleData(volvo);
            vehicleHash.Add("Volvo", volvoData);

           

        }

        public static NewVehicleData getValue(string key)
        {
            currentBrand = key;
            return vehicleHash[key];
        }
    }
}