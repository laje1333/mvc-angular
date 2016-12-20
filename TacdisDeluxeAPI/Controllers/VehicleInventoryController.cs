using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TacdisDeluxeAPI.Models;

namespace TacdisDeluxeAPI.Controllers
{
    public class VehicleInventoryController : ApiController
    {
        // GET: api/VehicleInventory
        public VehicleEntity GetSingleVehicleByRegnumber(string regNumber)
        {
            using (DBContext c = new DBContext())
            {
                return c.Vehicles.Distinct().Where(x => (x.RegNo.Equals(regNumber))).Single();

            }
        }

        // GET: api/VehicleInventory/5

        // POST: api/VehicleInventory
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/VehicleInventory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/VehicleInventory/5
        public void Delete(int id)
        {
        }
    }
}
