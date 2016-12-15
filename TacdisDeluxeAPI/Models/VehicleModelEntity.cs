using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacdisDeluxeAPI.Models
{
    [Table("VehicleModel")]
    public class VehicleModelEntity
    {
        public VehicleModelEntity()
        {
            Properties = new List<VehiclePropertyEntity>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public VehicleBrandEntity Brand { get; set; }
        public DateTime ProductionDate { get; set; }
        public virtual ICollection<VehiclePropertyEntity> Properties { get; set; }
    }
}
