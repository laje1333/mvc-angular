using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TacdisDeluxeAPI.Models;
using TacdisDeluxeAPI.Models.Enums;

namespace TacdisDeluxeAPI.Mockdata.InvoiceData
{
    public class GetMockInvoice
    {
        public static InvoiceEntity GetInvoice(int invoiceNumber, int woNumber)
        {
            var payer = new PayerEntity
            {
                Country = "Åmålandia",
                CustomerNumber = 100000,
                FirstName = "Kalle",
                LastName = "H",
                StreeatAddress = "Åmålgatan 1",
                ZipCity = "62141 Åmål",
                Id = 1
            };

            var invoiceRows = new List<InvoiceRowEntity>
            {
                new InvoiceRowEntity 
                {
                    Description = "Fin Bil", 
                    InvoiceRowAmount = 300000.90, 
                    Item = "245 Turbo", 
                    Quantity = 1, 
                    UnitCost = 300000.90, 
                    Vat = 75000
                }
            };

            var salesman = new SalesmanEntity
            {
                Company = "Volvo",
                Country = "Sverige",
                FirstName = "Urban",
                LastName = "Karlsson",
                StreeatAddress = "gatan 1",
                ZipCity = "123123 Volvoia",
                EmployeeNumber = 0,
                Id = 1
            };

            var invoice = new InvoiceEntity
            {
                InvoiceNumber = invoiceNumber,
                InvoiceState = InvoiceState.Preliminary,
                DueDate = DateTime.Now.AddDays(30),
                InvoiceDate = DateTime.Now,
                InvoiceAmount = 1000,
                WoNumber = woNumber,
                JobNumber = "1,2",
                DebitCredit = "debit",
                Vat = 250,
                AmountPaid = 0,
                InvoiceRows = invoiceRows,
                Salesman = salesman,
                Payer = payer
            };
            
            return invoice;
        }
    }
}