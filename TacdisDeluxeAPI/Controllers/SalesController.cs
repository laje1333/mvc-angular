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
    [Authorize]
    public class SalesController : ApiController
    {
        [Route("api/sales/AllSales")]
        [HttpGet]
        public IHttpActionResult AllSales()
        {
            using (DBContext db = new DBContext())
            {
                var allSales = db.Sales.Select(s => new { s.Id, s.Salesman, s.DateCreated, s.DateEdited, s.Payers }).ToList();
                return Ok(allSales);
            }

        }

        [Route("api/sales/GetSaleById")]
        [HttpGet]
        public IHttpActionResult GetSaleById(string id)
        {
            try {
                using (DBContext db = new DBContext())
                {
                    var sale = db.Sales.Include(x => x.Parts).Include(y => y.Salesman).Include(w => w.Vehicles)
                        .Where(z => z.Id.ToString() == id)
                        .Select(x => new { PartId = x.Parts.Select(y => y.ItemId), VehId = x.Vehicles.Select(y => y.ItemId) })
                        .FirstOrDefault();

                    return Ok(sale);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }

        [Route("api/sales/NewSale")]
        [HttpPost]
        public IHttpActionResult NewSale([FromBody]SalesDto request)
        {

            SaleEntity enti = new SaleEntity();
            
            try
            {
                using (DBContext db = new DBContext())
                {
                    List<PayerEntity> payers = new List<PayerEntity>();
                    List<VehicleEntity> vehs = new List<VehicleEntity>();
                    List<PartEntity> parts = new List<PartEntity>();
                    List<AddonEntity> addons = new List<AddonEntity>();

                    if (request.PayerIds != null)
                    {
                        foreach (int y in request.PayerIds)
                        {                           
                            payers.Add(db.Payers.Where(x => x.Id == y).FirstOrDefault());                           
                        }
                    }
                    if (request.VehicleIds != null)
                    {
                        foreach (int y in request.VehicleIds)
                        {
                            vehs.Add(db.Vehicles.Where(x => x.ItemId == y).FirstOrDefault());
                        }
                    }

                    if (request.PartIds != null)
                    {
                        foreach (IdAndAmountDto y in request.PartIds)
                        {
                            parts.Add(db.Parts.Where(x => x.ItemId == y.Id).FirstOrDefault());
                        }
                    }
                    
                    if(request.AddonIds != null)
                    {
                        foreach (int y in request.AddonIds)
                        {
                            addons.Add(db.Addons.Where(x => x.ItemId == y).FirstOrDefault());
                        }
                    }
                    
                    enti.Payers = payers;
                    enti.Vehicles = vehs;
                    enti.Parts = parts;
                    enti.Addons = addons;
                    enti.Salesman = request.Salesman;
                    enti.DateCreated = DateTime.Now;
                    enti.DateEdited = DateTime.Now;
                    db.Sales.Add(enti);

                    SalesmanEntity salesman = db.Salesmen.Where(x => x.Id == request.Salesman.Id).FirstOrDefault();
                    salesman.Sales.Add(enti);
                    db.SaveChanges();


                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(enti.Id);
        }

        [Route("api/sales/UpdateSale")]
        [HttpPatch]
        public IHttpActionResult UpdateSale([FromBody]SalesDto request)
        {

            try
            {
                using (DBContext db = new DBContext())
                {
                    SaleEntity enti = db.Sales.Where(x => x.Id == request.Id).FirstOrDefault();

                    if (request.PayerIds != null)
                    {
                        foreach (int y in request.PayerIds)
                        {
                            PayerEntity pay = db.Payers.Where(x => x.Id == y).FirstOrDefault();
                            if (!enti.Payers.Contains(pay))
                            {
                                enti.Payers.Add(pay);
                            }
                            
                        }
                    }
                    if (request.VehicleIds != null)
                    {
                        foreach (int y in request.VehicleIds)
                        {
                            VehicleEntity veh = db.Vehicles.Where(x => x.ItemId == y).FirstOrDefault();
                            if (!enti.Vehicles.Contains(veh))
                            {
                                enti.Vehicles.Add(veh);
                            }
                        }
                        
                    }

                    if (request.PartIds != null)
                    {
                        foreach (IdAndAmountDto y in request.PartIds)
                        {
                            PartEntity part = db.Parts.Where(x => x.ItemId == y.Id).FirstOrDefault();
                            if (!enti.Parts.Contains(part))
                            {
                                enti.Parts.Add(part);
                            }
                        }
                    }

                    if (request.AddonIds != null)
                    {
                        foreach (int y in request.AddonIds)
                        {
                            AddonEntity addon = db.Addons.Where(x => x.ItemId == y).FirstOrDefault();
                            if (!enti.Addons.Contains(addon))
                            {
                                enti.Addons.Add(addon);
                            }
                        }
                    }
                    if (enti.Salesman != request.Salesman && request.Salesman != null)
                    {
                        enti.Salesman = request.Salesman;
                    }                   
                    enti.DateEdited = DateTime.Now;
                    db.SaveChanges();

                    return Ok(enti.Id);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }
        
    }
}
