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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TacdisDeluxeAPI.Helpers.Invoice;

namespace TacdisDeluxeAPI.Controllers
{
    public class InvoiceController : ApiController
    {
        [System.Web.Http.Route("api/invoice/GetInvoice")]
        [System.Web.Http.HttpGet]
        public List<InvoiceDto> GetInvoice(string query)
        {
            var invoices = new List<InvoiceEntity>();

            try
            {
                using (var db = new DBContext())
                {
                    invoices = db.Invoices
                        .Include(p => p.Payer)
                        .Include(s => s.Salesman)
                        .Include(r => r.InvoiceRows)
                        .Where(i => i.InvoiceNumber.ToString().Contains(query) || i.RegNumber.ToString().Contains(query))
                        .ToList();
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

            return result.OrderByDescending(r => r.InvoiceNumber).ToList();
        }

        [System.Web.Http.Route("api/invoice/UpdateInvoice/Update")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult UpdateInvoice(InvoiceDto invoiceDto)
        {
            try
            {
                invoiceDto = InvoiceHelper.ValidateAndUpdateInvoiceDto(invoiceDto);
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
                    var originalSalesman = db.Salesmen.SingleOrDefault(s => s.Id == invoice.Salesman.Id);

                    var originalPayer = db.Payers.SingleOrDefault(p => p.Id == invoice.Payer.Id);

                    var originalInvoice = db.Invoices.SingleOrDefault(i => i.Id == invoice.Id);

                    if (originalInvoice != null)
                    {
                        var rowsToDelete = originalInvoice.InvoiceRows
                            .Where(ir => invoice.InvoiceRows.Select(oir => oir.Id)
                                .Contains(ir.Id) == false).ToList();

                        if (!InvoiceHelper.IsEqual(originalSalesman, invoice.Salesman))
                            db.Entry(originalSalesman).CurrentValues.SetValues(invoice.Salesman);

                        if (!InvoiceHelper.IsEqual(originalPayer, invoice.Payer))
                            db.Entry(originalPayer).CurrentValues.SetValues(invoice.Payer);

                        if (rowsToDelete.Any())
                            db.InvoiceRows.RemoveRange(rowsToDelete);

                        db.Entry(originalInvoice).CurrentValues.SetValues(invoice);
                        db.SaveChanges();
                    }
                    else
                        return BadRequest("Invoice not found!");
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
            InvoiceEntity invoice;

            try
            {
                invoice = InvoiceHelper.CreateInvoiceEntityFromSalesDto(salesDto);
            }
            catch (Exception ex)
            {
                return BadRequest("CreateInvoiceFromSales faild!");
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

            return Ok(invoice.InvoiceNumber);
        }

        [System.Web.Http.Route("api/invoice/CreatInvoice/CreateInvoiceFromWorkOrder")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateInvoiceFromWorkOrder(string workOrderId)
        {
            var invoice = new InvoiceEntity();

            var woh = new WorkOrderEntity();

            using (var db = new DBContext())
            {
                 woh = db.WorkOrder.SingleOrDefault(p => p.WoNr.ToString() == workOrderId);
            }

            try
            {
                invoice = InvoiceHelper.CreateInvoiceEntityFromWorkOrder(woh);
            }
            catch (Exception ex)
            {
                return BadRequest("CreateInvoiceFromWorkOrder faild!");
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
            return Ok(invoice.InvoiceNumber);
        }
    }
}
