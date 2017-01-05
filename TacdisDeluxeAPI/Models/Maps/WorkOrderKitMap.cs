using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.Models
{
    public class WorkOrderKitMap : EntityTypeConfiguration<WoKitsEntity>
    {
        public WorkOrderKitMap()
        {
            //HasMany<WoOpEntitys>(s => s.WOJ_OPList)
            //    .WithRequired(s => s.WoKits)
            //    .Map(m => m.MapKey("WorkOrderKitId"));

            //HasMany<PartEntity>(s => s.WOJ_PartList)
            //    .WithRequired(s => s.WoKits)
            //    .Map(m => m.MapKey("WorkOrderKitId"));
        }
    }
}
