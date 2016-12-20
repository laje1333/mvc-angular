using AutoMapper;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TacdisDeluxeAPI.DTO;
using TacdisDeluxeAPI.Models;
using System.Data.Entity;

namespace TacdisDeluxeAPI.Controllers
{
    public class SalesController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (DBContext db = new DBContext())
            {
                List<SaleEntity> allSales = db.Sales.Include(i => i.Salesman).ToList();
                return Ok(allSales);
            }

        }

        public IHttpActionResult Get1(Dictionary<string, string> searchPar)
        {
            using (DBContext db = new DBContext())
            {
                List<SaleEntity> allMatchingSales = new List<SaleEntity>();
                IQueryable<SaleEntity> allSalesStuff = db.Sales.Include("Salesman");
                foreach(KeyValuePair<string, string> a in searchPar)
                {
                    switch(a.Key){
                        case "SalesmanId":
                            allMatchingSales.AddRange(db.Sales.Include("Salesman").Where(x => x.Salesman.Id == Convert.ToInt32(a.Value)).ToList());
                            break;
                        case "SaleId":
                            allMatchingSales.AddRange(db.Sales.Include("Salesman").Where(x => x.Id == Convert.ToInt32(a.Value)).ToList());
                            break;
                        case "Status":
                            //todo
                            break;
                    }
                    
                }
                return Ok(allMatchingSales);
            }

        }

        public IHttpActionResult PostSale([FromBody]SalesDto request)
        {
            
            var enti = Mapper.Map<SalesDto, SaleEntity>(request);
            

            try
            {
                using (DBContext db = new DBContext())
                {
                    List<PartEntity> parts = db.Parts.Where(x => request.PartIds.Contains(x.Id)).ToList();
                    enti.Parts = parts;
                    db.Sales.Add(enti);
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
