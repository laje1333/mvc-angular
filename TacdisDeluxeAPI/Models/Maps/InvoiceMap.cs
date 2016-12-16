using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacdisDeluxeAPI.Models.Maps
{
    public class InvoiceMap : EntityTypeConfiguration<InvoiceEntity>
    {
        public InvoiceMap()
        {
            HasRequired<PayerEntity>(i => i.Payer);
            HasRequired<SalesmanEntity>(i => i.Salesman);

            HasMany<InvoiceRowEntity>(i => i.InvoiceRows)
                .WithRequired(r => r.Invoice)
                .Map(m => m.MapKey("InvoiceId"));
        }
    }
}
