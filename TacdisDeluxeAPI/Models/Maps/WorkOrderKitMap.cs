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
            HasMany<WoOpEntitys>(s => s.WOJ_OPList)
                .WithOptional(s => s.WoKits)
                .Map(m => m.MapKey("WoKits_Id"));

            HasMany<PartEntity>(s => s.WOJ_PartList)
                .WithMany(s => s.WoKits)
                .Map(m =>
                {
                    m.ToTable("WoKits_Parts");
                    m.MapLeftKey("WoKits_Id");
                    m.MapRightKey("PartId");
                });
        }
    }
}
