using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacdisDeluxeAPI.Models.Maps
{
    public class SaleMap : EntityTypeConfiguration<SaleEntity>
    {
        public SaleMap()
        {             

            HasMany<VehicleEntity>(s => s.Vehicles)
                .WithMany(s => s.Sales)
                .Map(m =>
                {
                    m.ToTable("Sales_Vehicles");
                    m.MapLeftKey("SaleId");
                    m.MapRightKey("VehicleId");
                });

            HasMany<PartEntity>(s => s.Parts)
                .WithMany(s => s.Sales)
                .Map(m =>
                {
                    m.ToTable("Sales_Parts");
                    m.MapLeftKey("SaleId");
                    m.MapRightKey("PartId");
                });
            
            HasMany<AddonEntity>(s => s.Addons)
                .WithMany(s => s.Sales)
                .Map(m =>
                {
                    m.ToTable("Sales_Addons");
                    m.MapLeftKey("SaleId");
                    m.MapRightKey("AddonId");
                });

            HasMany<PayerEntity>(s => s.Payers)
                .WithMany(s => s.Sales)
                .Map(m =>
                {
                    m.ToTable("Sales_Payers");
                    m.MapLeftKey("SaleId");
                    m.MapRightKey("PayerId");
                });
            
        }
    }
}
