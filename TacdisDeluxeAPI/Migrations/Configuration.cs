/*
Enable-Migrations -ContextTypeName TacdisDeluxeAPI.Models.DBContext
add-migration InitialCABLAMCreate
update-database -Verbose
add-migration
*/


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
            //Vehicle
            var vehicleBrands = new List<VehicleBrandEntity>()
            {
                new VehicleBrandEntity(){Id = 1, Name = "Volvo"},
                new VehicleBrandEntity(){Id = 2, Name = "Ford"},
                new VehicleBrandEntity(){Id = 3, Name = "Audi"},
                new VehicleBrandEntity(){Id = 4, Name = "BMW"}
            };

            vehicleBrands.ForEach(v =>
            {
                context.VehicleBrands.AddOrUpdate<VehicleBrandEntity>(v);
            });
            context.SaveChanges();

            var vehicleProperties = new List<VehiclePropertyEntity>()
            {
                //Engine types:
                new VehiclePropertyEntity(){Id = 1, Name = "Petrol"     , Field = "Engine-Type"},
                new VehiclePropertyEntity(){Id = 2, Name = "Diesel"     , Field = "Engine-Type"},

                //Engine groups:
                new VehiclePropertyEntity(){Id = 3, Name = "V6"         , Field = "Engine-Group"                    , ParentId = 1},
                new VehiclePropertyEntity(){Id = 4, Name = "V5"         , Field = "Engine-Group"                    , ParentId = 1},
                new VehiclePropertyEntity(){Id = 5, Name = "Flat 5 Cylinders"         , Field = "Engine-Group"      , ParentId = 1},
                new VehiclePropertyEntity(){Id = 6, Name = "V5"         , Field = "Engine-Group"                    , ParentId = 2},
                new VehiclePropertyEntity(){Id = 7, Name = "V6"         , Field = "Engine-Group"                    , ParentId = 2},

                //Engine descriptions:
                new VehiclePropertyEntity(){Id = 8, Name = "Standard-V6", Field = "Engine-Description", ParentId = 3, Price = 29990},
                new VehiclePropertyEntity(){Id = 9, Name = "Standard-V5", Field = "Engine-Description", ParentId = 4, Price = 26490},
                new VehiclePropertyEntity(){Id = 10, Name = "Flat 5 Petrol", Field = "Engine-Description", ParentId = 5, Price = 23490},
                new VehiclePropertyEntity(){Id = 11, Name = "Standard-V5", Field = "Engine-Description", ParentId = 6, Price = 32500},
                new VehiclePropertyEntity(){Id = 12, Name = "Standard-V6", Field = "Engine-Description", ParentId = 7, Price = 37490},

                //Transmission types:
                new VehiclePropertyEntity(){Id = 13, Name = "Automatic"     , Field = "Transmission-Type"},
                new VehiclePropertyEntity(){Id = 14, Name = "Manual"        , Field = "Transmission-Type"},

                //Transmission groups:
                new VehiclePropertyEntity(){Id = 15, Name = "5 Gears"       , Field = "Transmission-Group", ParentId = 13},
                new VehiclePropertyEntity(){Id = 16, Name = "6 Gears"       , Field = "Transmission-Group", ParentId = 13},
                new VehiclePropertyEntity(){Id = 17, Name = "6 Gears"       , Field = "Transmission-Group", ParentId = 14},
                new VehiclePropertyEntity(){Id = 18, Name = "5 Gears"       , Field = "Transmission-Group", ParentId = 14},

                //Transmission descriptions:
                new VehiclePropertyEntity(){Id = 19, Name = "Standard-Automatic 6-gears", Field = "Transmission-Description", ParentId = 16, Price = 26500},
                new VehiclePropertyEntity(){Id = 20, Name = "Standard-Automatic 5-gears", Field = "Transmission-Description", ParentId = 15, Price = 23490},
                new VehiclePropertyEntity(){Id = 21, Name = "Standard-Manual 6-gears",    Field = "Transmission-Description", ParentId = 17, Price = 22500},
                new VehiclePropertyEntity(){Id = 22, Name = "Standard-Manual 5-gears",    Field = "Transmission-Description", ParentId = 18, Price = 19490},


                 //Exterior paint types:
                new VehiclePropertyEntity(){Id = 23, Name = "White",     Field = "Exterior-Type"},
                new VehiclePropertyEntity(){Id = 24, Name = "Brown",     Field = "Exterior-Type"},
                new VehiclePropertyEntity(){Id = 25, Name = "Dark-Gray", Field = "Exterior-Type"},

                 //Exterior paint groups:
                 new VehiclePropertyEntity(){Id = 26, Name = "Matte-Powder Painted", Field = "Exterior-Group", ParentId = 23},
                 new VehiclePropertyEntity(){Id = 27, Name = "Clear",                Field = "Exterior-Group", ParentId = 23},
                 new VehiclePropertyEntity(){Id = 28, Name = "Matte-Powder Painted", Field = "Exterior-Group", ParentId = 24},
                 new VehiclePropertyEntity(){Id = 29, Name = "Clear",                Field = "Exterior-Group", ParentId = 24},
                 new VehiclePropertyEntity(){Id = 30, Name = "Clear",                Field = "Exterior-Group", ParentId = 25},

                 //Exerior paint descriptions:
                 new VehiclePropertyEntity(){Id = 31, Name = "White matte finish",        Field = "Exterior-Description", ParentId = 26, Price = 23490},
                 new VehiclePropertyEntity(){Id = 32, Name = "White clear finish",        Field = "Exterior-Description", ParentId = 27, Price = 26490},
                 new VehiclePropertyEntity(){Id = 33, Name = "Brown matte finish",        Field = "Exterior-Description", ParentId = 28, Price = 23490},
                 new VehiclePropertyEntity(){Id = 34, Name = "Brown clear finish",        Field = "Exterior-Description", ParentId = 29, Price = 26490},
                 new VehiclePropertyEntity(){Id = 35, Name = "Dark-Gray clear finish",    Field = "Exterior-Description", ParentId = 30, Price = 28490},

                //Interior material types:
                new VehiclePropertyEntity(){Id = 36, Name = "Leather",      Field = "Interior-Material"},
                new VehiclePropertyEntity(){Id = 37, Name = "Polyester",    Field = "Interior-Material"},
                new VehiclePropertyEntity(){Id = 38, Name = "Wool",         Field = "Interior-Material"},

                 //Interior colors:
                 new VehiclePropertyEntity(){Id = 39, Name = "Brown ",               Field = "Interior-Color", ParentId = 36},
                 new VehiclePropertyEntity(){Id = 40, Name = "Black",                Field = "Interior-Color", ParentId = 36},
                 new VehiclePropertyEntity(){Id = 41, Name = "White",                Field = "Interior-Color", ParentId = 37},
                 new VehiclePropertyEntity(){Id = 42, Name = "Gray",                 Field = "Interior-Color", ParentId = 37},
                 new VehiclePropertyEntity(){Id = 43, Name = "Blue",                 Field = "Interior-Color", ParentId = 38},

                 //Interior descriptions:
                 new VehiclePropertyEntity(){Id = 44, Name = "Brown leather interior",    Field = "Interior-Description", ParentId = 39, Price = 34490},
                 new VehiclePropertyEntity(){Id = 45, Name = "Black leather interior",    Field = "Interior-Description", ParentId = 40, Price = 31490},
                 new VehiclePropertyEntity(){Id = 46, Name = "White polyester",           Field = "Interior-Description", ParentId = 41, Price = 23490},
                 new VehiclePropertyEntity(){Id = 47, Name = "Gray polyester",            Field = "Interior-Description", ParentId = 42, Price = 24490},
                 new VehiclePropertyEntity(){Id = 48, Name = "Blue wool interior",        Field = "Interior-Description", ParentId = 43, Price = 17490},


            };

            vehicleProperties.ForEach(v =>
            {
                context.VehicleProperties.AddOrUpdate<VehiclePropertyEntity>(v);
            });
            context.SaveChanges();



            var vehicleModels = new List<VehicleModelEntity>()
            {
                new VehicleModelEntity(){Id = 1, BrandId = 1, Name = "XC-90", Brand = vehicleBrands[0], ProductionDate = new DateTime(2011, 1, 1), Properties = vehicleProperties},
            };

            vehicleModels.ForEach(v =>
            {
                context.VehicleModels.AddOrUpdate<VehicleModelEntity>(v);
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
