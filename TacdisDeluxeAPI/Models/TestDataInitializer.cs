using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacdisDeluxeAPI.Models
{
    public class TestDataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            //DateTime.Parse("2005-09-01")

            var parts = new List<PartEntity>
            {
                new PartEntity() { Id = 1, ItemName = "Rubber thing", ItemId = 1, ItemPrice = 500.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ItemName = "Bandaid", ItemId = 2, ItemPrice = 675.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ItemName = "A piece of tape", ItemId = 3, ItemPrice = 850.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ItemName = "Ballbearing", ItemId = 4, ItemPrice = 1025.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ItemName = "Screw", ItemId = 5, ItemPrice = 1200.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ItemName = "Random stuff", ItemId = 6, ItemPrice = 1375.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ItemName = "General copper pipe", ItemId = 7, ItemPrice = 1550.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ItemName = "Break disc", ItemId = 8, ItemPrice = 1725.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ItemName = "Piston", ItemId = 9, ItemPrice = 1900.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ItemName = "Nail, 9 inch", ItemId = 10, ItemPrice = 2075.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ItemName = "Rubber hose", ItemId = 11, ItemPrice = 2250.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ItemName = "Spycam", ItemId = 12, ItemPrice = 2425.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ItemName = "10A fuse", ItemId = 13, ItemPrice = 2600.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ItemName = "16A fuse", ItemId = 14, ItemPrice = 2775.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ItemName = "Battery 12V", ItemId = 15, ItemPrice = 2950.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ItemName = "Air filter interior", ItemId = 16, ItemPrice = 3125.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ItemName = "Air filter exterior", ItemId = 17, ItemPrice = 3300.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ItemName = "Engine block", ItemId = 18, ItemPrice = 3475.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ItemName = "Steering wheel", ItemId = 19, ItemPrice = 3650.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ItemName = "Gearbox 6g", ItemId = 20, ItemPrice = 3825.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ItemName = "Gearbox 5g", ItemId = 21, ItemPrice = 4000.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ItemName = "Gearbox DST", ItemId = 22, ItemPrice = 4175.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ItemName = "Turbo super awesome thingomabob", ItemId = 23, ItemPrice = 4350.5f, SpecFsg = false, VAT = 0.25f }
            };

            parts.ForEach(p => context.Parts.Add(p));
            context.SaveChanges();

        }
    }
}
