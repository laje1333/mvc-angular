using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacdisDeluxeAPI.Models.Enums;

namespace TacdisDeluxeAPI.Models
{
    [Table("Sale")]
    public class SaleEntity
    {
        public SaleEntity()
        {
            Vehicles = new List<VehicleEntity>();
            Parts = new List<PartEntity>();
            Addons = new List<SalesAddonEntity>();
            Payers = new List<PayerEntity>();
        }

        [Key]
        public int Id { get; set; }
        public SalesmanEntity Salesman { get; set; }
        public virtual ICollection<VehicleEntity> Vehicles { get; set; }
        public virtual ICollection<PartEntity> Parts { get; set; }
        public SalesStatus Status { get; set; }
        public virtual ICollection<SalesAddonEntity> Addons { get; set; }
        public virtual ICollection<PayerEntity> Payers { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
