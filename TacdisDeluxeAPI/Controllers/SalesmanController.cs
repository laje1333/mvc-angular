using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TacdisDeluxeAPI.DTO;
using TacdisDeluxeAPI.Models;

namespace TacdisDeluxeAPI.Controllers
{
    public class SalesmanController : ApiController
    {
        // GET: api/Sales
        public IHttpActionResult Get(string FirstName, string LastName, string Company)
        {
            using (DBContext db = new DBContext())
            {
                IQueryable<SalesmanEntity> allSalesmen;

                if (string.IsNullOrEmpty(FirstName + LastName + Company))
                {
                    return Ok(new List<SalesmanEntity>());
                }
                else
                {
                    allSalesmen = db.Salesmen as IQueryable<SalesmanEntity>;
                }

                if (!String.IsNullOrEmpty(FirstName))
                {
                    allSalesmen = allSalesmen.Where(p => p.FirstName.ToString().Contains(FirstName));
                }

                if (!String.IsNullOrEmpty(LastName))
                {
                    allSalesmen = allSalesmen.Where(p => p.LastName.Contains(LastName));
                }

                if (!String.IsNullOrEmpty(Company))
                {
                    allSalesmen = allSalesmen.Where(p => p.Company.Contains(Company));
                }

                return Ok(allSalesmen.ToList());
            }

        }
       


        public IHttpActionResult PostSalesman([FromBody]SalesmanDto request)
        {
            var enti = Mapper.Map<SalesmanDto, SalesmanEntity>(request);

            try
            {
                using (DBContext db = new DBContext())
                {
                    //validate and stuff before adding the new salesman
                    db.Salesmen.Add(enti);
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
