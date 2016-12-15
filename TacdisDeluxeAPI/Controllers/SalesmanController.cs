using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TacdisDeluxeAPI.Models;

namespace TacdisDeluxeAPI.Controllers
{
    public class SalesmanController : ApiController
    {
        // GET: api/Sales
        public IQueryable<SalesmanEntity> GetParts()
        {
            using(DBContext db = new DBContext())
            {
                return db.Salesmen;
            }
            
        }


        public IHttpActionResult PostSale([FromBody]SalesmanEntity request)
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    db.Salesmen.Add(request);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
