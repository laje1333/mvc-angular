using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using TacdisDeluxeAPI.DTO;
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
                List<PartDto> parts = new List<PartDto>();

                var ps = c.Parts;

                if (ps.Any())
                {
                    var pes = ps.ToList();
                    parts = Mapper.Map<List<PartEntity>, List<PartDto>>(pes);
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

        public IHttpActionResult Get(string ItemId)
        {
            using (DBContext c = new DBContext())
            {
                PartDto part = null;

                try
                {
                    var pe = c.Parts.Where(p => p.ItemId == int.Parse(ItemId)).Single();
                    part = Mapper.Map<PartEntity, PartDto>(pe);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return Ok(part);
            }
        }


        public IHttpActionResult Get(string ItemId, string ItemName)
        {
            using (DBContext c = new DBContext())
            {
                IQueryable<PartEntity> allParts;

                if (string.IsNullOrEmpty(ItemName + ItemId))
                {
                    return Ok(new List<PartEntity>());
                }
                else
                {
                    allParts = c.Parts as IQueryable<PartEntity>;
                }

                if (!String.IsNullOrEmpty(ItemId))
                {
                    allParts = allParts.Where(p => p.ItemId.ToString().Contains(ItemId));
                }

                if (!String.IsNullOrEmpty(ItemName))
                {
                    allParts = allParts.Where(p => p.ItemName.Contains(ItemName));
                }

                return Ok(allParts.ToList());
            }

        }


        public IHttpActionResult Post([FromBody]PartDto part)
        {
            PartDto responseDto = null;

            try
            {
                var entity = Mapper.Map<PartDto, PartEntity>(part);

                using (DBContext db = new DBContext())
                {
                    db.Parts.Add(entity);
                    db.SaveChanges();

                    responseDto = Mapper.Map<PartEntity, PartDto>(entity);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(responseDto);
        }


        public IHttpActionResult Delete(int id)
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    var entity = db.Parts.Where(p => p.Id == id).SingleOrDefault();
                    db.Parts.Remove(entity);
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
