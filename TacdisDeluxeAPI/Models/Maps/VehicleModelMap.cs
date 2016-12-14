using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacdisDeluxeAPI.Models.Maps
{
    public class VehicleModelMap : EntityTypeConfiguration<VehicleModelEntity>
    {
        public VehicleModelMap()
        {
            HasMany<VehiclePropertyEntity>(v => v.Properties);
        }
    }
}
