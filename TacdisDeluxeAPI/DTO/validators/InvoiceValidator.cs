using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TacdisDeluxeAPI.Models;

namespace TacdisDeluxeAPI.DTO.validators
{
    public class InvoiceValidator
    {
        public static InvoiceDto ValidateAndUpdateInvoiceDto(InvoiceDto invoice)
        {
            invoice.InvoiceNumber = invoice.InvoiceNumber ?? GetInvoiceNumber();

            if (invoice.Payer != null)
                invoice.Payer.CustomerNumber = invoice.Payer.CustomerNumber ?? GetCustomerNumber();

            invoice.Vat = invoice.Vat ?? 0;
            invoice.InvoiceAmount = invoice.InvoiceAmount ?? 0;
            invoice.AmountPaid = invoice.AmountPaid ?? 0;

            if (invoice.InvoiceRows == null) return invoice;
            foreach (var row in invoice.InvoiceRows)
            {
                row.Vat = row.Vat ?? 0;
                row.Quantity = row.Quantity ?? 0;
                row.UnitCost = row.UnitCost ?? 0;
                row.InvoiceRowAmount = row.InvoiceRowAmount ?? 0;
            }


            return invoice;
        }

        private static int GetInvoiceNumber()
        {
            using (var db = new DBContext())
            {
                var newInvoiceNumber = db.Invoices.Max(i => i.InvoiceNumber);
                return ++newInvoiceNumber;
            }
        }
        private static int GetCustomerNumber()
        {
            using (var db = new DBContext())
            {
                var newCustomerNumber = db.Payers.Max(i => i.CustomerNumber);
                return ++newCustomerNumber;
            }
        }
    }
}