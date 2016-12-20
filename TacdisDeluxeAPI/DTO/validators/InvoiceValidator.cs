using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TacdisDeluxeAPI.Models;

namespace TacdisDeluxeAPI.DTO.validators
{
    public class InvoiceValidator
    {
        public static InvoiceDto ValidateAndUpdateInvoiceDto(InvoiceDto invoice)
        {
            invoice.InvoiceNumber = invoice.InvoiceNumber ?? GetInvoiceNumber();

            if (invoice.Payer != null && invoice.Payer.CustomerNumber != null)
                invoice.Payer = GetCustomer(invoice.Payer);

            if (invoice.Payer != null)
                invoice.Payer.CustomerNumber = invoice.Payer.CustomerNumber ?? GetCustomerNumber();

            invoice.Salesman = GetSalesman(invoice.Salesman);

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
                var newCustomerNumber = db.Payers.Max(c => c.CustomerNumber);
                return ++newCustomerNumber;
            }
        }

        private static PayerDto GetCustomer(PayerDto payer)
        {
            using (var db = new DBContext())
            {
                var customer = db.Payers.Single(p => p.CustomerNumber == payer.CustomerNumber);
                return customer != null ? Mapper.Map<PayerEntity, PayerDto>(customer) : payer;
            }
        }

        private static SalesmanDto GetSalesman(SalesmanDto salesman)
        {
            using (var db = new DBContext())
            {
                var employ = db.Salesmen.Single(s => s.EmployeeNumber == salesman.EmployeeNumber);
                return employ != null ? Mapper.Map<SalesmanEntity, SalesmanDto>(employ) : salesman;
            }
        }
    }
}