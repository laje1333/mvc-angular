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
            //var invoices = "{\"invoices\":[{\"InvoiceNumber\": \"1213001\",\"InvoiceState\": \"Makulerad\",\"WoNumber\": \"1105427\",\"JobNumber\": \"1,2\",\"Payer\": \"Harry Olsson\",\"RegNumber\":\"FBI123\",\"CustomerNumber\": \"6467737220\",\"InvoiceDate\": \"2016-11-29\",\"DueDate\": \"2016-12-29\",\"DebitCredit\": \"Debit\",\"Vat\": \"250\",\"InvoiceAmount\": \"1000\"},{\"InvoiceNumber\": \"1213002\",\"InvoiceState\": \"Bokförd\",\"WoNumber\": \"1105428\",\"JobNumber\": \"1\",\"Payer\": \"Ronny Hök\",\"RegNumber\": \"CIA123\",\"CustomerNumber\": \"6467737220\",\"InvoiceDate\": \"2016-11-29\",\"DueDate\": \"2016-12-29\",\"DebitCredit\": \"Debit\",\"Vat\": \"125\",\"InvoiceAmount\": \"500\"},{\"InvoiceNumber\": \"1213003\",\"InvoiceState\": \"Makulerad\",\"WoNumber\": \"1105429\",\"JobNumber\": \"2\",\"Payer\": \"Konny Kofot\",\"RegNumber\": \"KGB123\",\"CustomerNumber\": \"6467737220\",\"InvoiceDate\": \"2016-11-29\",\"DueDate\": \"2016-12-29\",\"DebitCredit\": \"Credit\",\"Vat\": \"500\",\"InvoiceAmount\": \"2000\"},{\"InvoiceNumber\": \"1213004\",\"InvoiceState\": \"Makulerad\",\"WoNumber\": \"1105427\",\"JobNumber\": \"1,2\",\"Payer\": \"Harry Olsson\",\"RegNumber\":\"FBI123\",\"CustomerNumber\": \"6467737220\",\"InvoiceDate\": \"2016-11-29\",\"DueDate\": \"2016-12-29\",\"DebitCredit\": \"Debit\",\"Vat\": \"250\",\"InvoiceAmount\": \"1000\"},{\"InvoiceNumber\": \"1213005\",\"InvoiceState\": \"Bokförd\",\"WoNumber\": \"1105428\",\"JobNumber\": \"1\",\"Payer\": \"Ronny Hök\",\"RegNumber\": \"CIA123\",\"CustomerNumber\": \"6467737220\",\"InvoiceDate\": \"2016-11-29\",\"DueDate\": \"2016-12-29\",\"DebitCredit\": \"Debit\",\"Vat\": \"125\",\"InvoiceAmount\": \"500\"},{\"InvoiceNumber\": \"1213006\",\"InvoiceState\": \"Makulerad\",\"WoNumber\": \"1105429\",\"JobNumber\": \"2\",\"Payer\": \"Konny Kofot\",\"RegNumber\": \"KGB123\",\"CustomerNumber\": \"6467737220\",\"InvoiceDate\": \"2016-11-29\",\"DueDate\": \"2016-12-29\",\"DebitCredit\": \"Credit\",\"Vat\": \"500\",\"InvoiceAmount\": \"2000\"},{\"InvoiceNumber\": \"1213007\",\"InvoiceState\": \"Makulerad\",\"WoNumber\": \"1105427\",\"JobNumber\": \"1,2\",\"Payer\": \"Harry Olsson\",\"RegNumber\":\"FBI123\",\"CustomerNumber\": \"6467737220\",\"InvoiceDate\": \"2016-11-29\",\"DueDate\": \"2016-12-29\",\"DebitCredit\": \"Debit\",\"Vat\": \"250\",\"InvoiceAmount\": \"1000\"},{\"InvoiceNumber\": \"1213008\",\"InvoiceState\": \"Bokförd\",\"WoNumber\": \"1105428\",\"JobNumber\": \"1\",\"Payer\": \"Ronny Hök\",\"RegNumber\": \"CIA123\",\"CustomerNumber\": \"6467737220\",\"InvoiceDate\": \"2016-11-29\",\"DueDate\": \"2016-12-29\",\"DebitCredit\": \"Debit\",\"Vat\": \"125\",\"InvoiceAmount\": \"500\"},{\"InvoiceNumber\": \"1213009\",\"InvoiceState\": \"Makulerad\",\"WoNumber\": \"1105429\",\"JobNumber\": \"2\",\"Payer\": \"Konny Kofot\",\"RegNumber\": \"KGB123\",\"CustomerNumber\": \"6467737220\",\"InvoiceDate\": \"2016-11-29\",\"DueDate\": \"2016-12-29\",\"DebitCredit\": \"Credit\",\"Vat\": \"500\",\"InvoiceAmount\": \"2000\"},{\"InvoiceNumber\": \"1213010\",\"InvoiceState\": \"Makulerad\",\"WoNumber\": \"1105427\",\"JobNumber\": \"1,2\",\"Payer\": \"Harry Olsson\",\"RegNumber\":\"FBI123\",\"CustomerNumber\": \"6467737220\",\"InvoiceDate\": \"2016-11-29\",\"DueDate\": \"2016-12-29\",\"DebitCredit\": \"Debit\",\"Vat\": \"250\",\"InvoiceAmount\": \"1000\"},{\"InvoiceNumber\": \"1213011\",\"InvoiceState\": \"Bokförd\",\"WoNumber\": \"1105428\",\"JobNumber\": \"1\",\"Payer\": \"Ronny Hök\",\"RegNumber\": \"CIA123\",\"CustomerNumber\": \"6467737220\",\"InvoiceDate\": \"2016-11-29\",\"DueDate\": \"2016-12-29\",\"DebitCredit\": \"Debit\",\"Vat\": \"125\",\"InvoiceAmount\": \"500\"},{\"InvoiceNumber\": \"1213012\",\"InvoiceState\": \"Makulerad\",\"WoNumber\": \"1105429\",\"JobNumber\": \"2\",\"Payer\": \"Konny Kofot\",\"RegNumber\": \"KGB123\",\"CustomerNumber\": \"6467737220\",\"InvoiceDate\": \"2016-11-29\",\"DueDate\": \"2016-12-29\",\"DebitCredit\": \"Credit\",\"Vat\": \"500\",\"InvoiceAmount\": \"2000\"}]}";

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

        [System.Web.Http.Route("api/invoice/CreatInvoice/Create")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateInvoice(InvoiceDto invoiceDto)
        {

            //Test
            //var mockInvoice = GetMockInvoice.GetInvoice(2, 2, 12);
            //invoiceDto = Mapper.Map<InvoiceEntity, InvoiceDto>(mockInvoice);

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
