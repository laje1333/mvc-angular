using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using TacdisDeluxeAPI.Mockdata.VehicleData;

namespace TacdisDeluxeAPI.Controllers
{
    public class VehicleController : ApiController
    {
        // GET: api/Vehicle
        [System.Web.Http.HttpGet]
        public string Get()
        {

            return " ";                
        }



        // GET: api/Vehicle/5
        public string Get(int id)
        {
            switch (id)
            {
                case 1:
                    return NewVehicleDataHash.getValue("Volvo").getAttr();
                case 2:
                    return NewVehicleDataHash.getValue("Ford").getAttr();
            }

            return " ";
        }

        // POST: api/Vehicle
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Vehicle/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Vehicle/5
        public void Delete(int id)
        {
        }
    }
}
