using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacdisDeluxeAPI.Models.Maps
{
    public class SalesmanMap : EntityTypeConfiguration<SalesmanEntity>
    {
        public SalesmanMap()
        {

            HasMany<SaleEntity>(s => s.Sales)
                .WithOptional(s => s.Salesman)
                .Map(m => m.MapKey("Sale_Id"));

        }
    }
}
