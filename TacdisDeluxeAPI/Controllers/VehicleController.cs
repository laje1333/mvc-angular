using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TacdisDeluxeAPI.Controllers
{
    public class VehicleController : ApiController
    {
        // GET: api/Vehicle
        [HttpGet]
        public IEnumerable<string> Get(int id)
        {
            switch(id){
                case 1:
                    Console.WriteLine("hej");
                    break;
            }
                


            return new string[] { "value1", "value2" };
        }

        // GET: api/Vehicle/5
        public string Get(int id)
        {
            return "value";
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
