using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.Models
{
    public class WorkOrderJobMap : EntityTypeConfiguration<WoJobEntity>
    {
        public WorkOrderJobMap()
        {
            //HasMany<WoKitsEntity>(s => s.WOJ_KitList)
            //    .WithRequired(s => s.WoJob)
            //    .Map(m => m.MapKey("WorkOrderJobId"));

            //HasMany<WoOpEntitys>(s => s.WOJ_OPList)
            //    .WithRequired(s => s.WoJob)
            //    .Map(m => m.MapKey("WorkOrderJobId"));

            //HasMany<PartEntity>(s => s.WOJ_PartList)
            //    .WithRequired(s => s.WoJob)
            //    .Map(m => m.MapKey("WorkOrderJobId"));
        }
    }
}
