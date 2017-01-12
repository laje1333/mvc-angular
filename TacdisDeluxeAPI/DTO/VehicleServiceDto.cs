using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TacdisDeluxeAPI.Models;

namespace TacdisDeluxeAPI.DTO
{
    public class VehicleServiceDto
    {
        public string wohId { get; set; }
        public string RegNr { get; set; }
        public string VehDesc { get; set; }
        public DateTime VehRegDate { get; set; }
        public string VehOwner { get; set; }
        public string VehDriver { get; set; }
        public string VehPhoneNr { get; set; }
        public DateTime VehLastVisDate { get; set; }
        public string VehLastVisMil { get; set; }
    }
}