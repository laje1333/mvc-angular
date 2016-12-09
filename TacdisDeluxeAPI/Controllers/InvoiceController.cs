using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace TacdisDeluxeAPI.Controllers
{
    public class InvoiceController : ApiController
    {
        // GET api/invoice
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/invoice/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // GET api/invoice/GetInvoice/123423
        [System.Web.Http.HttpGet]
        public string GetInvoice(int query)
        {
            var invoices = "[{{\"InvoiceNumber\": \"1213074\",\"InvoiceState\": \"Makulerad\",\"WoNumber\": \"1105427\",\"JobNumber\": \"1,2\",\"Payer\": \"Harry Olsson\",\"RegNumber\":\"FBI123\",\"CustomerNumber\": \"6467737220\",\"InvoiceDate\": \"2016-11-29\",\"DueDate\": \"2016-12-29\",\"DebitCredit\": \"Debit\",\"Vat\": \"250\",\"InvoiceAmount\": \"1000\"}},{{\"InvoiceNumber\": \"1213075\",\"InvoiceState\": \"Bokförd\",\"WoNumber\": \"1105428\",\"JobNumber\": \"1\",\"Payer\": \"Ronny Hök\",\"RegNumber\": \"CIA123\",\"CustomerNumber\": \"6467737220\",\"InvoiceDate\": \"2016-11-29\",\"DueDate\": \"2016-12-29\",\"DebitCredit\": \"Debit\",\"Vat\": \"125\",\"InvoiceAmount\": \"500\"}},{{\"InvoiceNumber\": \"1213076\",\"InvoiceState\": \"Makulerad\",\"WoNumber\": \"1105429\",\"JobNumber\": \"2\",\"Payer\": \"Konny Kofot\",\"RegNumber\": \"KGB123\",\"CustomerNumber\": \"6467737220\",\"InvoiceDate\": \"2016-11-29\",\"DueDate\": \"2016-12-29\",\"DebitCredit\": \"Credit\",\"Vat\": \"500\",\"InvoiceAmount\": \"2000\"}}]";

            return invoices;
        }

        // POST api/invoice
        public void Post([FromBody]string value)
        {
        }

        // PUT api/invoice/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/invoice/5
        public void Delete(int id)
        {
        }
    }
}
