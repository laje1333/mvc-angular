using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TacdisDeluxeAPI.Models
{
    public class VehicleEntity
    {
        [Key]
        public int Id { get; set; }
        public string RegNo { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public string ItemDesc { get; set; }
        public double VAT { get; set; }
        public virtual PayerEntity Owner { get; set; }
        public double Milage { get; set; }
        public DateTime LastServiceDate { get; set; }

        [IgnoreDataMember]
        public ICollection<SaleEntity> Sales { get; internal set; }
        public VehicleModelEntity VehicleModel { get; set; }
    }
}
