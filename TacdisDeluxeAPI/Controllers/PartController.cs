using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using TacdisDeluxeAPI.Models;

//  Ordernummer: 1981657 - Butiksförsäljning Tacdis

namespace TacdisDeluxeAPI.Controllers
{
    public class PartController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (DBContext c = new DBContext())
            {
                List<PartEntity> parts = new List<PartEntity>();

                var ps = c.Parts;

                if (ps.Any())
                {
                    parts = ps.ToList();
                }

                return Ok(parts.ToList());
            }
        }

        public IHttpActionResult Get(int id)
        {
            using (DBContext c = new DBContext())
            {
                PartEntity part = null;

                try
                {
                    part = c.Parts.Where(p => p.Id == id).Single();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return Ok(part);
            }
        }


        public IHttpActionResult Get(string articleNumber, string articleName)
        {
            using (DBContext c = new DBContext())
            {
                IQueryable<PartEntity> allParts;

                if (string.IsNullOrEmpty(articleName + articleNumber))
                {
                    return Ok(new List<PartEntity>());
                }
                else
                {
                    allParts = c.Parts as IQueryable<PartEntity>;
                }

                if (!String.IsNullOrEmpty(articleNumber))
                {
                    allParts = allParts.Where(p => p.ArticleNumber.ToString().Contains(articleNumber));
                }

                if (!String.IsNullOrEmpty(articleName))
                {
                    allParts = allParts.Where(p => p.ArticleName.Contains(articleName));
                }

                return Ok(allParts.ToList());
            }

        }


        public IHttpActionResult Post([FromBody]PartEntity part)
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    db.Parts.Add(part);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
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
