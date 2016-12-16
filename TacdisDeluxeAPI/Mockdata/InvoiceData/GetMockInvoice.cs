using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TacdisDeluxeAPI.Models;

namespace TacdisDeluxeAPI.Mockdata.InvoiceData
{
    public class GetMockInvoice
    {
        public static InvoiceEntity GetInvoice(int invoiceNumber, int woNumber, int customerNumber)
        {
            var payer = new PayerEntity
            {
                Country = "Sverige",
                CustomerNumber = customerNumber,
                FirsName = "Anders",
                LastName = "Andersson",
                StreeatAddress = "Gatan 2",
                ZipCity = "666 66 Säffle"
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

            var invoice = new InvoiceEntity
            {
                InvoiceNumber = invoiceNumber,
                InvoiceState = "makulerad",
                DueDate = "2016-12-29",
                InvoiceDate = "2016-11-29",
                InvoiceAmount = 1000,
                WoNumber = woNumber,
                JobNumber = "1,2",
                DebitCredit = "debit",
                Vat = 250,
                AmountPaid = 0,
                InvoiceRows = invoiceRows,
                //EmployeeNumber = 123456,
                Payer = payer
            };

            var salesman = new SalesmanEntity
            {
                Company = "Bil Ab",
                Country = "Sverige",
                FirstName = "Olle",
                LastName = "Svensson",
                StreeatAddress = "gatan 1",
                ZipCity = "666 66 Åmål",
                EmployeeNumber = 123456
            };

            return invoice;
        }
    }
}