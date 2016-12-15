using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacdisDeluxeAPI.Models
{
    public class VehicleEntity
    {
        [Key]
        public int Id { get; set; }
        public string RegNo { get; set; }
        public ICollection<SaleEntity> Sales { get; internal set; }
        public VehicleModelEntity VehicleModel { get; set; }
    }
}
