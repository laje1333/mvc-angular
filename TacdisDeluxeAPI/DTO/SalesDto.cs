using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TacdisDeluxeAPI.Models;
using TacdisDeluxeAPI.Models.Enums;

namespace TacdisDeluxeAPI.DTO
{
    public class SalesDto
    {
        public int Id { get; set; }

        public SalesmanEntity Salesman { get; set; }
        public int[] VehicleIds { get; set; }
        public IdAndAmountDto PartIds { get; set; }
        public SalesStatus Status { get; set; }
        public int[] AddonIds { get; set; }
        public int[] PayerIds { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEdited { get; set; }
    }
}