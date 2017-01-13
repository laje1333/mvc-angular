using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TacdisDeluxeAPI.DTO;
using TacdisDeluxeAPI.Models;
using System.Data.Entity;
using TacdisDeluxeAPI.Helpers.Invoice;

namespace TacdisDeluxeAPI.Controllers
{
    public class InvoiceController : ApiController
    {
        [Route("api/invoice/GetInvoice")]
        [HttpGet]
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
                throw ex;
            }

            var result = invoices.Select(Mapper.Map<InvoiceEntity, InvoiceDto>).OrderByDescending(r => r.InvoiceNumber).ToList();

            return result;
        }

        [Route("api/invoice/UpdateInvoice/Update")]
        [HttpPost]
        public IHttpActionResult UpdateInvoice(InvoiceDto invoiceDto)
        {
            try
            {
                invoiceDto = InvoiceHelper.ValidateAndUpdateInvoiceDto(invoiceDto);
            }
            catch (Exception)
            {
                return BadRequest("Validation fail!");
            }

            InvoiceEntity invoice;

            try
            {
                invoice = Mapper.Map<InvoiceDto, InvoiceEntity>(invoiceDto);
            }
            catch (Exception)
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

        [Route("api/invoice/CreateInvoice/CreateInvoiceFromSales")]
        [HttpPost]
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

        [Route("api/invoice/CreateInvoice/CreateInvoiceFromWorkOrder")]
        [HttpPost]
        public IHttpActionResult CreateInvoiceFromWorkOrder(string workOrderId)
        {
            var invoice = new InvoiceEntity();

            var woh = new WorkOrderEntity();

            using (var db = new DBContext())
            {
                woh = db.WorkOrder
                    .Include(p => p.MainPayer)
                    .Include(s => s.RespBy)
                    .Include(w => w.WOJ_List.Select(i => i.WOJ_PartList_Ids))
                    .SingleOrDefault(p => p.WoNr.ToString() == workOrderId);
            }

            try
            {
                invoice = InvoiceHelper.CreateInvoiceEntityFromWorkOrder(woh);
            }
            catch (Exception)
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
