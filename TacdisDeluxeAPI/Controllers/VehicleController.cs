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



        // GET: api/Vehicle/5




        //id = brand, panel = model/engine/transmission...
        [System.Web.Http.HttpGet]
        public string GetVehicle(string brand)
        {

             return NewVehicleDataHash.getValue(brand).getModelAttr();

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
