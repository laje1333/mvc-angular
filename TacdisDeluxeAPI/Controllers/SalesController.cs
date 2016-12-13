using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TacdisDeluxeAPI.Controllers
{
    public class SalesController : ApiController
    {
        public string Get()
        {
            return "Part,Vehicle";
        }

        public void Put(int id, FormCollection values)
        {
            
        }
    }
}
