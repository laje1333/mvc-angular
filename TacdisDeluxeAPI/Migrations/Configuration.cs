namespace TacdisDeluxeAPI.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TacdisDeluxeAPI.Models.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TacdisDeluxeAPI.Models.DBContext context)
        {





            var parts = new List<PartEntity>()
            {
                new PartEntity() { Id = 1, ArticleName = "Rubber thing", ArticleNumber = 14309, Price = 500.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 2, ArticleName = "Bandaid", ArticleNumber = 14376, Price = 675.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 3, ArticleName = "A piece of tape", ArticleNumber = 14443, Price = 850.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 4, ArticleName = "Ballbearing", ArticleNumber = 14510, Price = 1025.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 5, ArticleName = "Screw", ArticleNumber = 14577, Price = 1200.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 6, ArticleName = "Random stuff", ArticleNumber = 14644, Price = 1375.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 7, ArticleName = "General copper pipe", ArticleNumber = 14711, Price = 1550.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 8, ArticleName = "Break disc", ArticleNumber = 14778, Price = 1725.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 9, ArticleName = "Piston", ArticleNumber = 14845, Price = 1900.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 10, ArticleName = "Nail, 9 inch", ArticleNumber = 14912, Price = 2075.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 11, ArticleName = "Rubber hose", ArticleNumber = 14979, Price = 2250.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 12, ArticleName = "Spycam", ArticleNumber = 15046, Price = 2425.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 13, ArticleName = "10A fuse", ArticleNumber = 15113, Price = 2600.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 14, ArticleName = "16A fuse", ArticleNumber = 15180, Price = 2775.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 15, ArticleName = "Battery 12V", ArticleNumber = 15247, Price = 2950.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 16, ArticleName = "Air filter interior", ArticleNumber = 15314, Price = 3125.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 17, ArticleName = "Air filter exterior", ArticleNumber = 15381, Price = 3300.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 18, ArticleName = "Engine block", ArticleNumber = 15448, Price = 3475.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 19, ArticleName = "Steering wheel", ArticleNumber = 15515, Price = 3650.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 20, ArticleName = "Gearbox 6g", ArticleNumber = 15582, Price = 3825.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 21, ArticleName = "Gearbox 5g", ArticleNumber = 15649, Price = 4000.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 22, ArticleName = "Gearbox DST", ArticleNumber = 15716, Price = 4175.5f, SpecFsg = false, VAT = 0.25f },
                new PartEntity() { Id = 23, ArticleName = "Turbo super awesome thingomabob", ArticleNumber = 15783, Price = 4350.5f, SpecFsg = false, VAT = 0.25f },
            };

            parts.ForEach(p =>
            {
                context.Parts.AddOrUpdate<PartEntity>(p);
            });
            context.SaveChanges();








            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
