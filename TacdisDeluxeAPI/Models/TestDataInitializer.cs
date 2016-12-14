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
                new PartEntity() { Id = 1, ArticleName = "Rubber thing", ArticleNumber = 1, Price = 500.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ArticleName = "Bandaid", ArticleNumber = 2, Price = 675.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ArticleName = "A piece of tape", ArticleNumber = 3, Price = 850.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ArticleName = "Ballbearing", ArticleNumber = 4, Price = 1025.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ArticleName = "Screw", ArticleNumber = 5, Price = 1200.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ArticleName = "Random stuff", ArticleNumber = 6, Price = 1375.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ArticleName = "General copper pipe", ArticleNumber = 7, Price = 1550.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ArticleName = "Break disc", ArticleNumber = 8, Price = 1725.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ArticleName = "Piston", ArticleNumber = 9, Price = 1900.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ArticleName = "Nail, 9 inch", ArticleNumber = 10, Price = 2075.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ArticleName = "Rubber hose", ArticleNumber = 11, Price = 2250.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ArticleName = "Spycam", ArticleNumber = 12, Price = 2425.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ArticleName = "10A fuse", ArticleNumber = 13, Price = 2600.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ArticleName = "16A fuse", ArticleNumber = 14, Price = 2775.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ArticleName = "Battery 12V", ArticleNumber = 15, Price = 2950.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ArticleName = "Air filter interior", ArticleNumber = 16, Price = 3125.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ArticleName = "Air filter exterior", ArticleNumber = 17, Price = 3300.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ArticleName = "Engine block", ArticleNumber = 18, Price = 3475.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ArticleName = "Steering wheel", ArticleNumber = 19, Price = 3650.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ArticleName = "Gearbox 6g", ArticleNumber = 20, Price = 3825.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ArticleName = "Gearbox 5g", ArticleNumber = 21, Price = 4000.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ArticleName = "Gearbox DST", ArticleNumber = 22, Price = 4175.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 1, ArticleName = "Turbo super awesome thingomabob", ArticleNumber = 23, Price = 4350.5f, SpecFsg = false, VAT = 0.25f }
            };

            parts.ForEach(p => context.Parts.Add(p));
            context.SaveChanges();

        }
    }
}
