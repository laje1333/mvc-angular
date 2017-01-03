using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using TacdisDeluxeAPI.DTO;
using TacdisDeluxeAPI.Mockdata.InvoiceData;
using TacdisDeluxeAPI.Models;
using TacdisDeluxeAPI.DTO.validators;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace TacdisDeluxeAPI.Controllers
{
    public class InvoiceController : ApiController
    {
        // GET api/invoice/GetInvoice/123423
        [System.Web.Http.HttpGet]
        public List<InvoiceDto> GetInvoice(string query)
        {
           
            var invoices = new List<InvoiceEntity>();

            try
            {
                using (var db = new DBContext())
                {
                   invoices = db.Invoices.Include(p => p.Payer).Include(s => s.Salesman).Include(r => r.InvoiceRows).Where(i => i.InvoiceNumber.ToString().Contains(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            var result = new List<InvoiceDto>();

            foreach (var invoice in invoices)
            {
                result.Add(Mapper.Map<InvoiceEntity, InvoiceDto>(invoice));
            }
            
            return result;
        }

        [System.Web.Http.Route("api/invoice/UpdateInvoice/Update")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult UpdateInvoice(InvoiceDto invoiceDto)
        {
            try
            {
                invoiceDto = InvoiceValidator.ValidateAndUpdateInvoiceDto(invoiceDto);
            }
            catch (Exception ex)
            {

                return BadRequest("Validation fail!");
            }

            InvoiceEntity invoice;
            try
            {
                invoice = Mapper.Map<InvoiceDto, InvoiceEntity>(invoiceDto);
            }
            catch (Exception ex)
            {

                return BadRequest("Invoice mapping error!");
            }

            try
            {
                using (var db = new DBContext())
                {
                    db.Payers.Attach(invoice.Payer);
                    db.Salesmen.Attach(invoice.Salesman);

                    var original = db.Invoices.Single(i => i.Id == invoice.Id);

                    db.Entry(original).CurrentValues.SetValues(invoice);

                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();

        }

        [System.Web.Http.Route("api/invoice/CreatInvoice/CreateInvoiceFromSales")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateInvoiceFromSales(SalesDto salesDto)
        {

            var invoice = new InvoiceEntity();

            try
            {
                invoice = InvoiceValidator.CreateInvoiceEntityFromSalesDto(salesDto);
            }
            catch (Exception ex)
            {

                return BadRequest("Validation fail!");
            }
            
            try
            {
                using (var db = new DBContext())
                {
                    db.Payers.Attach(invoice.Payer);
                    db.Salesmen.Attach(invoice.Salesman);

                    db.Invoices.Add(invoice);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }


        //// POST api/invoice
        //public void Post([FromBody]string value)
        //{
        //    var mockInvoice = GetMockInvoice.GetInvoice(1, 1, 12);

        //    var dto = Mapper.Map<InvoiceEntity, InvoiceDto>(mockInvoice);

        //}

        //// PUT api/invoice/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/invoice/5
        //public void Delete(int id)
        //{
        //}
    }
}
