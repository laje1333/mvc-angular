using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using TacdisDeluxeAPI.Models;

namespace TacdisDeluxeAPI.Controllers
{
    public class PartController : ApiController
    {
        [System.Web.Http.HttpGet]
        public string Kalle(int id)
        {
            return "Rulez!" + " id = " + id;
        }

        //// GET: api/Part
        //public string Get()
        //{
        //    return "Wohoo!";
        //}

        //// GET: api/Part/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Part
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Part/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Part/5
        //public void Delete(int id)
        //{
        //}
    }
}
