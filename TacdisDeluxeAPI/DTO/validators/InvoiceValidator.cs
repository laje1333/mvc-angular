using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TacdisDeluxeAPI.Models;
using TacdisDeluxeAPI.Models.Enums;

namespace TacdisDeluxeAPI.DTO.validators
{
    public class InvoiceValidator
    {
        public static InvoiceDto ValidateAndUpdateInvoiceDto(InvoiceDto invoice)
        {
            invoice.InvoiceNumber = invoice.InvoiceNumber ?? GetInvoiceNumber();

            //if (invoice.Payer != null && invoice.Payer.Id != null)
            //    invoice.Payer = GetCustomer(invoice.Payer);

            //if (invoice.Payer != null)
            //    invoice.Payer.CustomerNumber = invoice.Payer.CustomerNumber ?? GetCustomerNumber();

            //invoice.Salesman = GetSalesman(invoice.Salesman);

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

        public static InvoiceEntity CreateInvoiceEntityFromSalesDto(SalesDto salesDto)
        {
            var invoice = new InvoiceEntity
            {
                InvoiceNumber = GetInvoiceNumber(),
                Salesman = salesDto.Salesman,
                InvoiceState = InvoiceState.Preliminary,
                InvoiceDate = salesDto.DateCreated,
                DueDate = salesDto.DateCreated.AddDays(30),
                DebitCredit = "Debit",
                WoNumber = 0,
                JobNumber = string.Empty,
                Payer = GetPayer(salesDto.PayerIds.First()),
                InvoiceRows = new List<InvoiceRowEntity>()
            };

            if (salesDto.PartIds != null && salesDto.PartIds.Count > 0)
            {
                var invoiceRows = GetInvoiceRowFromParts(salesDto.PartIds);
                foreach (var row in invoiceRows)
                {
                    invoice.InvoiceRows.Add(row);
                }
            }

            if (salesDto.VehicleIds != null && salesDto.VehicleIds.Length > 0)
            {
                invoice.RegNumber = GetRegNumber(salesDto.VehicleIds.FirstOrDefault());

                var invoiceRows = GetInvoiceRowFromVehicle(salesDto.VehicleIds);
                foreach (var row in invoiceRows)
                {
                    invoice.InvoiceRows.Add(row);
                }
            }

            if (salesDto.AddonIds != null && salesDto.AddonIds.Length > 0)
            {
                var invoiceRows = GetInvoiceRowFromAddon(salesDto.AddonIds);
                foreach (var row in invoiceRows)
                {
                    invoice.InvoiceRows.Add(row);
                }
            }

            if (invoice.InvoiceRows.Count > 0)
            {
                invoice.Vat = invoice.InvoiceRows.FirstOrDefault().Vat;

                foreach (var row in invoice.InvoiceRows)
                {
                    invoice.InvoiceAmount += row.InvoiceRowAmount;
                }
            }


            return invoice;
        }

        public static InvoiceEntity CreateInvoiceEntityFromWorkOrderDto(WorkOrderEntity workOrderDto)
        {
            var invoice = new InvoiceEntity
            {
                InvoiceNumber = GetInvoiceNumber(),
                //Salesman = workOrderDto.Salesman,
                InvoiceState = InvoiceState.Preliminary,
                InvoiceDate = workOrderDto.CreatedDate,
                DueDate = workOrderDto.CreatedDate.AddDays(30),
                DebitCredit = "Debit",
                WoNumber = workOrderDto.WoNr,
                //JobNumber = string.Join(", ", workOrderDto.WOJ_Ids),
                //Payer = GetPayer(workOrderDto.PayerIds.First()),
                InvoiceRows = new List<InvoiceRowEntity>()
            };

            return invoice;
        }

        private static List<InvoiceRowEntity> GetInvoiceRowFromParts(IEnumerable<IdAndAmountDto> partsIds)
        {
            var invoiceRows = new List<InvoiceRowEntity>();

            foreach (var IA in partsIds)
            {
                using (var db = new DBContext())
                {
                    var part = db.Parts.SingleOrDefault(p => p.ItemId == IA.Id);
                    invoiceRows.Add(new InvoiceRowEntity
                    {
                        Id = part.Id,
                        Item = part.ItemName,
                        Description = part.ItemDesc,
                        UnitCost = part.ItemPrice,
                        Vat = part.VAT,
                        Quantity = IA.Amount,
                        InvoiceRowAmount = part.ItemPrice * IA.Amount
                    });
                }
            }
            return invoiceRows;
        }

        private static List<InvoiceRowEntity> GetInvoiceRowFromVehicle(int[] vehiclesIds)
        {
            var invoiceRows = new List<InvoiceRowEntity>();

            foreach (var id in vehiclesIds)
            {
                using (var db = new DBContext())
                {
                    var vehicle = db.Vehicles.SingleOrDefault(v => v.ItemId == id);
                    invoiceRows.Add(new InvoiceRowEntity
                    {
                        Id = vehicle.Id,
                        Item = vehicle.ItemName,
                        Description = vehicle.ItemDesc,
                        UnitCost = vehicle.ItemPrice,
                        Vat = vehicle.VAT,
                        Quantity = 1, //todo fixa kvantitet
                        InvoiceRowAmount = vehicle.ItemPrice //todo gånger Quantity
                    });
                }
            }
            return invoiceRows;
        }

        private static List<InvoiceRowEntity> GetInvoiceRowFromAddon(int[] addonIds)
        {
            var invoiceRows = new List<InvoiceRowEntity>();

            foreach (var id in addonIds)
            {
                using (var db = new DBContext())
                {
                    var addon = db.Addons.SingleOrDefault(a => a.ItemId == id);
                    invoiceRows.Add(new InvoiceRowEntity
                    {
                        Id = addon.Id,
                        Item = addon.ItemName,
                        Description = addon.ItemDesc,
                        UnitCost = addon.ItemPrice,
                        Vat = addon.VAT,
                        Quantity = 1, //todo fixa kvantitet
                        InvoiceRowAmount = addon.ItemPrice //todo gånger Quantity
                    });
                }
            }
            return invoiceRows;
        }
        private static string GetRegNumber(int id)
        {
            string regNumber;
            using (var db = new DBContext())
            {
                var vehicle = db.Vehicles.Single(v => v.ItemId == id);
                regNumber = vehicle.RegNo;
            }

            return regNumber;
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

        private static PayerEntity GetPayer(int id)
        {
            using (var db = new DBContext())
            {
                var payer = db.Payers.Single(p => p.Id == id);
                return payer;
            }
        }

        private static PayerDto GetCustomer(PayerDto payer)
        {
            using (var db = new DBContext())
            {
                var customer = db.Payers.Single(p => p.Id == payer.Id);
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

        public static bool IsEqual(PayerEntity x, PayerEntity y)
        {
            return (x.Id == y.Id &&
                x.FirstName == y.FirstName &&
                x.LastName == y.LastName &&
                x.CustomerNumber == y.CustomerNumber &&
                x.StreeatAddress == y.StreeatAddress &&
                x.ZipCity == y.ZipCity &&
                x.Country == y.Country);
        }

        public static bool IsEqual(SalesmanEntity x, SalesmanEntity y)
        {
            return (x.Id == y.Id &&
                x.FirstName == y.FirstName &&
                x.LastName == y.LastName &&
                x.EmployeeNumber == y.EmployeeNumber &&
                x.StreeatAddress == y.StreeatAddress &&
                x.ZipCity == y.ZipCity &&
                x.Country == y.Country &&
                x.Company == y.Company);
        }
    }
}