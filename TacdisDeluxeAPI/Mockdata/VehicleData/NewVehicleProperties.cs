using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.Mockdata.VehicleData
{
    public class NewVehicleProperties
    {
        //General
        public string Brand { get; set; }
        public string ModelYear { get; set; }
        public string Model { get; set; }

        //Engine
        public string EngineType { get; set; }
        public string EngineGroup { get; set; }
        public string EngineDescription { get; set; }

        //Transmission
        public string TransmissionType { get; set; }
        public string TransmissionGroup { get; set; }
        public string TransmissionDescription { get; set; }

        //Exterior
        public string PaintType { get; set; }
        public string PaintDescription { get; set; }
        public string PaintGroup { get; set; }

        //Exterior
        public string InteriorMaterial { get; set; }
        public string InteriorColorDescription { get; set; }
        public string InteriorColor { get; set; }

        public static List<NewVehicleProperties> vehicles = new List<NewVehicleProperties>();

        public static void addVehicleToRecord(NewVehicleProperties vehicle)
        {
            vehicles.Add(vehicle);
        }

        public static List<NewVehicleProperties> getVehicles()
        {
            return vehicles;
        }
    }
}