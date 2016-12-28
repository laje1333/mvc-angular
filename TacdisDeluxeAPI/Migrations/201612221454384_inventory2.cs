namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inventory2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MainInventory", newName: "MainInventoryEntities");
            RenameTable(name: "dbo.MainInventoryConnection", newName: "MainInventoryPartEntities");
            RenameTable(name: "dbo.WorkshopInventoryConnection", newName: "WorkshopInventoryPartEntities");
            DropColumn("dbo.MainInventoryPartEntities", "PartId");
            RenameColumn(table: "dbo.MainInventoryPartEntities", name: "MainInventoryId", newName: "PartId");
            RenameIndex(table: "dbo.MainInventoryPartEntities", name: "IX_MainInventoryId", newName: "IX_PartId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.MainInventoryPartEntities", name: "IX_PartId", newName: "IX_MainInventoryId");
            RenameColumn(table: "dbo.MainInventoryPartEntities", name: "PartId", newName: "MainInventoryId");
            AddColumn("dbo.MainInventoryPartEntities", "PartId", c => c.Int(nullable: false));
            RenameTable(name: "dbo.WorkshopInventoryPartEntities", newName: "WorkshopInventoryConnection");
            RenameTable(name: "dbo.MainInventoryPartEntities", newName: "MainInventoryConnection");
            RenameTable(name: "dbo.MainInventoryEntities", newName: "MainInventory");
        }
    }
}
