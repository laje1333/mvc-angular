using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TacdisDeluxeAPI.Models;

namespace TacdisDeluxeAPI.Controllers
{
    public class BrandController : ApiController
    {
        // GET: api/Brand

        public IEnumerable<VehicleBrandEntity> GetVehicleBrands()
        {
            using (DBContext c = new DBContext())
            {
                var brands = c.VehicleBrands;

                return brands.ToList();
            }
        }

        // POST: api/Brand
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Brand/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Brand/5
        public void Delete(int id)
        {
        }
    }
}
