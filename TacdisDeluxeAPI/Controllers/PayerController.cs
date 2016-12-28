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
    public class PayerController : ApiController
    {
        public IHttpActionResult Get(int CustNr)
        {
            using (DBContext db = new DBContext())
            {
                PayerEntity payer = db.Payers.Where(x => x.CustomerNumber == CustNr).FirstOrDefault<PayerEntity>();
                if (payer != null)
                {
                    return Ok(payer);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        // GET: api/Payer
        public IHttpActionResult Get(string FirstName, string LastName, string CustNr)
        {
            using (DBContext db = new DBContext())
            {
                IQueryable<PayerEntity> allPayers;

                if (string.IsNullOrEmpty(FirstName + LastName + CustNr))
                {
                    return Ok(new List<PayerEntity>());
                }
                else
                {
                    allPayers = db.Payers as IQueryable<PayerEntity>;
                }

                if (!String.IsNullOrEmpty(FirstName))
                {
                    allPayers = allPayers.Where(p => p.FirstName.ToString().Contains(FirstName));
                }

                if (!String.IsNullOrEmpty(LastName))
                {
                    allPayers = allPayers.Where(p => p.LastName.Contains(LastName));
                }

                if (!String.IsNullOrEmpty(CustNr))
                {
                    allPayers = allPayers.Where(p => p.CustomerNumber.ToString().Contains(CustNr));
                }

                return Ok(allPayers.ToList());
            }
        }


        // POST: api/Payer
        public IHttpActionResult Post([FromBody]PayerDto value)
        {
            var enti = Mapper.Map<PayerDto, PayerEntity>(value);

            try
            {
                using (DBContext db = new DBContext())
                {
                    //validate and stuff before adding the new salesman
                    PayerEntity p = db.Payers.OrderByDescending(x => x.Id).FirstOrDefault();
                    if (p != null)
                    {
                        enti.CustomerNumber = p.CustomerNumber + 1; 
                    }
                    else
                    {
                        enti.CustomerNumber = 100000;
                    }
                    db.Payers.Add(enti);
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
