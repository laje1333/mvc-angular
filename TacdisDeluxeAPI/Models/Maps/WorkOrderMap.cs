using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.Models.Maps
{
    public class WorkOrderMap : EntityTypeConfiguration<WorkOrderEntity>
    {
        public WorkOrderMap()
        {
            HasMany<WoJobEntity>(s => s.WOJ_List)
                .WithRequired(s => s.WorkOrder)
                .Map(m => m.MapKey("WorkOrder_WoNr"));
        }
    }
}