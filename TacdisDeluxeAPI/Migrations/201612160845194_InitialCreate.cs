namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesAddon",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        VAT = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sale",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        PaymentType = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateEdited = c.DateTime(nullable: false),
                        Salesman_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Salesman", t => t.Salesman_Id)
                .Index(t => t.Salesman_Id);
            
            CreateTable(
                "dbo.Part",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleNumber = c.Int(nullable: false),
                        ArticleName = c.String(),
                        Price = c.Double(nullable: false),
                        VAT = c.Double(nullable: false),
                        SpecFsg = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirsName = c.String(),
                        LastName = c.String(),
                        Trusted = c.Boolean(nullable: false),
                        CustomerNumber = c.String(),
                        StreeatAddress = c.String(),
                        ZipCity = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Salesman",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Company = c.String(),
                        StreeatAddress = c.String(),
                        ZipCity = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegNo = c.String(),
                        VehicleModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleModel", t => t.VehicleModel_Id)
                .Index(t => t.VehicleModel_Id);
            
            CreateTable(
                "dbo.VehicleModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BrandId = c.Int(nullable: false),
                        ProductionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleBrand", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.VehicleBrand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleProperty",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Field = c.String(),
                        ParentId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        VehicleModelEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleModel", t => t.VehicleModelEntity_Id)
                .Index(t => t.VehicleModelEntity_Id);
            
            CreateTable(
                "dbo.Sales_Addons",
                c => new
                    {
                        SaleId = c.Int(nullable: false),
                        AddonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SaleId, t.AddonId })
                .ForeignKey("dbo.Sale", t => t.SaleId, cascadeDelete: true)
                .ForeignKey("dbo.SalesAddon", t => t.AddonId, cascadeDelete: true)
                .Index(t => t.SaleId)
                .Index(t => t.AddonId);
            
            CreateTable(
                "dbo.Sales_Parts",
                c => new
                    {
                        SaleId = c.Int(nullable: false),
                        PartId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SaleId, t.PartId })
                .ForeignKey("dbo.Sale", t => t.SaleId, cascadeDelete: true)
                .ForeignKey("dbo.Part", t => t.PartId, cascadeDelete: true)
                .Index(t => t.SaleId)
                .Index(t => t.PartId);
            
            CreateTable(
                "dbo.Sales_Payers",
                c => new
                    {
                        SaleId = c.Int(nullable: false),
                        PayerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SaleId, t.PayerId })
                .ForeignKey("dbo.Sale", t => t.SaleId, cascadeDelete: true)
                .ForeignKey("dbo.Payer", t => t.PayerId, cascadeDelete: true)
                .Index(t => t.SaleId)
                .Index(t => t.PayerId);
            
            CreateTable(
                "dbo.Sales_Vehicles",
                c => new
                    {
                        SaleId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SaleId, t.VehicleId })
                .ForeignKey("dbo.Sale", t => t.SaleId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicle", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.SaleId)
                .Index(t => t.VehicleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales_Vehicles", "VehicleId", "dbo.Vehicle");
            DropForeignKey("dbo.Sales_Vehicles", "SaleId", "dbo.Sale");
            DropForeignKey("dbo.Vehicle", "VehicleModel_Id", "dbo.VehicleModel");
            DropForeignKey("dbo.VehicleProperty", "VehicleModelEntity_Id", "dbo.VehicleModel");
            DropForeignKey("dbo.VehicleModel", "BrandId", "dbo.VehicleBrand");
            DropForeignKey("dbo.Sale", "Salesman_Id", "dbo.Salesman");
            DropForeignKey("dbo.Sales_Payers", "PayerId", "dbo.Payer");
            DropForeignKey("dbo.Sales_Payers", "SaleId", "dbo.Sale");
            DropForeignKey("dbo.Sales_Parts", "PartId", "dbo.Part");
            DropForeignKey("dbo.Sales_Parts", "SaleId", "dbo.Sale");
            DropForeignKey("dbo.Sales_Addons", "AddonId", "dbo.SalesAddon");
            DropForeignKey("dbo.Sales_Addons", "SaleId", "dbo.Sale");
            DropIndex("dbo.Sales_Vehicles", new[] { "VehicleId" });
            DropIndex("dbo.Sales_Vehicles", new[] { "SaleId" });
            DropIndex("dbo.Sales_Payers", new[] { "PayerId" });
            DropIndex("dbo.Sales_Payers", new[] { "SaleId" });
            DropIndex("dbo.Sales_Parts", new[] { "PartId" });
            DropIndex("dbo.Sales_Parts", new[] { "SaleId" });
            DropIndex("dbo.Sales_Addons", new[] { "AddonId" });
            DropIndex("dbo.Sales_Addons", new[] { "SaleId" });
            DropIndex("dbo.VehicleProperty", new[] { "VehicleModelEntity_Id" });
            DropIndex("dbo.VehicleModel", new[] { "BrandId" });
            DropIndex("dbo.Vehicle", new[] { "VehicleModel_Id" });
            DropIndex("dbo.Sale", new[] { "Salesman_Id" });
            DropTable("dbo.Sales_Vehicles");
            DropTable("dbo.Sales_Payers");
            DropTable("dbo.Sales_Parts");
            DropTable("dbo.Sales_Addons");
            DropTable("dbo.VehicleProperty");
            DropTable("dbo.VehicleBrand");
            DropTable("dbo.VehicleModel");
            DropTable("dbo.Vehicle");
            DropTable("dbo.Salesman");
            DropTable("dbo.Payer");
            DropTable("dbo.Part");
            DropTable("dbo.Sale");
            DropTable("dbo.SalesAddon");
        }
    }
}
