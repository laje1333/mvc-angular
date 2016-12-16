using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TacdisDeluxeAPI.Models
{
    public class VehiclePropertyEntity
    {
        public VehiclePropertyEntity()
        {
            ParentId = 0;
            Price = 0;
        }

        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Field { get; set; }
        public int ParentId { get; set; }

        public double Price { get; set; }

        [IgnoreDataMember]
        public VehicleModelEntity VehicleModel { get; set; }
    }
}
