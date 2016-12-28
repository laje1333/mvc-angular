namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inventory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MainInventory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MainInventoryConnection",
                c => new
                    {
                        MainInventoryId = c.Int(nullable: false),
                        PartId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MainInventoryId, t.PartId })
                .ForeignKey("dbo.MainInventory", t => t.MainInventoryId, cascadeDelete: true)
                .Index(t => t.MainInventoryId);
            
            CreateTable(
                "dbo.WorkshopInventory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MainInventoryEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MainInventory", t => t.MainInventoryEntity_Id)
                .Index(t => t.MainInventoryEntity_Id);
            
            CreateTable(
                "dbo.WorkshopInventoryConnection",
                c => new
                    {
                        workshopID = c.Int(nullable: false),
                        PartId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.workshopID, t.PartId })
                .ForeignKey("dbo.WorkshopInventory", t => t.workshopID, cascadeDelete: true)
                .Index(t => t.workshopID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkshopInventory", "MainInventoryEntity_Id", "dbo.MainInventory");
            DropForeignKey("dbo.WorkshopInventoryConnection", "workshopID", "dbo.WorkshopInventory");
            DropForeignKey("dbo.MainInventoryConnection", "MainInventoryId", "dbo.MainInventory");
            DropIndex("dbo.WorkshopInventoryConnection", new[] { "workshopID" });
            DropIndex("dbo.WorkshopInventory", new[] { "MainInventoryEntity_Id" });
            DropIndex("dbo.MainInventoryConnection", new[] { "MainInventoryId" });
            DropTable("dbo.WorkshopInventoryConnection");
            DropTable("dbo.WorkshopInventory");
            DropTable("dbo.MainInventoryConnection");
            DropTable("dbo.MainInventory");
        }
    }
}
