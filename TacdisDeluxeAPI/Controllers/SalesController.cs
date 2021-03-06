﻿using AutoMapper;
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

        [Route("api/sales/DeleteSale")]
        [HttpDelete]
        public IHttpActionResult DeleteSale(int id)
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    SaleEntity saleToDelete = db.Sales.Include("Salesman").FirstOrDefault(x => x.Id == id);
                    SalesmanEntity deleteSaleOnSalesman = db.Salesmen.FirstOrDefault(x => x.Id == saleToDelete.Salesman.Id);
                    if (deleteSaleOnSalesman != null) deleteSaleOnSalesman.Sales.Remove(saleToDelete);
                    db.Sales.Remove(saleToDelete);
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
                        .Select(x => new { Id = x.Id, Parts = x.Parts.Select(y => new { ItemId = y.ItemId, ItemName = y.ItemName, ItemPrice = y.ItemPrice }), Veh = x.Vehicles.Select(y => new { ItemId = y.ItemId, ItemName = y.ItemName, ItemPrice = y.ItemPrice }), Salesman = x.Salesman, Status = x.Status, Payers = x.Payers, Addons = x.Addons })
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
                        payers.AddRange(request.PayerIds.Select(y => db.Payers.FirstOrDefault(x => x.Id == y)));
                    }
                    if (request.VehicleIds != null)
                    {
                        vehs.AddRange(request.VehicleIds.Select(y => db.Vehicles.Where(x => x.ItemId == y).FirstOrDefault()));
                    }

                    if (request.PartIds != null)
                    {
                        parts.AddRange(request.PartIds.Select(y => db.Parts.FirstOrDefault(x => x.ItemId == y.Id)));
                    }
                    
                    if(request.AddonIds != null)
                    {
                        addons.AddRange(request.AddonIds.Select(y => db.Addons.FirstOrDefault(x => x.ItemId == y)));
                    }
                    
                    enti.Payers = payers;
                    enti.Vehicles = vehs;
                    enti.Parts = parts;
                    enti.Addons = addons;
                    enti.Status = request.Status;
                    enti.Salesman = db.Salesmen.FirstOrDefault(x => x.Id == request.Salesman.Id);
                    enti.DateCreated = DateTime.Now;
                    enti.DateEdited = DateTime.Now;
                    db.Sales.Add(enti);

                    SalesmanEntity salesman = db.Salesmen.FirstOrDefault(x => x.Id == request.Salesman.Id);
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
        public IHttpActionResult UpdateSale(SalesDto request)
        {

            try
            {
                using (DBContext db = new DBContext())
                {
                    SaleEntity enti = db.Sales.Include("Salesman").FirstOrDefault(x => x.Id == request.Id);
                    if (enti.Payers.First().Id != request.PayerIds[0])
                    {
                        PayerEntity removeFirst = enti.Payers.First();
                        enti.Payers.Remove(removeFirst);
                        enti.Payers.Add(db.Payers.FirstOrDefault(x => x.Id == request.PayerIds[0]));
                    }
                    else if(request.PayerIds == null)
                    {
                        return BadRequest("Sale most have a payer");
                    }
                    if (enti.Vehicles.Count != 0 || request.VehicleIds != null)
                    {

                        List<VehicleEntity> veh = new List<VehicleEntity>();
                        List<VehicleEntity> vehToRemove = new List<VehicleEntity>();
                        
                        foreach (VehicleEntity v in enti.Vehicles)
                        {
                            if (request.VehicleIds == null)
                            {
                                vehToRemove.Add(v);
                            }
                            else if (!request.VehicleIds.Contains(v.ItemId))
                            {
                                vehToRemove.Add(v);
                            }
                        }
                        foreach (VehicleEntity v in vehToRemove)
                        {
                            enti.Vehicles.Remove(v);
                        }

                        int len = request.VehicleIds == null ? 0 : request.VehicleIds.Length;
                        for (int i = 0; i < len ; i++ )
                        {
                            if (enti.Vehicles.All(x => x.ItemId != request.VehicleIds[i]))
                            {
                                enti.Vehicles.Add(db.Vehicles.FirstOrDefault(x => x.ItemId == request.VehicleIds[i]));
                            }
                        }
                    }

                    if (enti.Parts.Count != 0 || request.PartIds != null)
                    {
                        List<PartEntity> parts = new List<PartEntity>();
                        List<PartEntity> partsToRemove = new List<PartEntity>();
                        foreach (PartEntity part in enti.Parts)
                        {
                            if (request.PartIds == null)
                            {
                                partsToRemove.Add(part);
                            }
                            else
                            {
                                if (request.PartIds.All(x => x.Id != part.ItemId))
                                {
                                    partsToRemove.Add(part);
                                }
                                else
                                {
                                    request.PartIds.Remove(request.PartIds.FirstOrDefault(x => x.Id == part.ItemId));
                                }
                            }
                            
                        }
                        foreach (PartEntity p in partsToRemove)
                        {
                            enti.Parts.Remove(p);
                        }
                        if (request.PartIds != null)
                        {
                            foreach (IdAndAmountDto y in request.PartIds)
                            {
                                enti.Parts.Add(db.Parts.FirstOrDefault(x => x.ItemId == y.Id));
                            }  
                        }
                          
                    }

                    if (enti.Salesman.Id != request.Salesman.Id && request.Salesman != null)
                    {
                        enti.Salesman = request.Salesman;
                    }
                    enti.Status = request.Status;
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
