namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleModel_VehicleProperties_connection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleProperty", "VehicleModelEntity_Id", "dbo.VehicleModel");
            DropIndex("dbo.VehicleProperty", new[] { "VehicleModelEntity_Id" });
            RenameColumn(table: "dbo.VehicleProperty", name: "VehicleModelEntity_Id", newName: "VehicleModelId");
            AlterColumn("dbo.VehicleProperty", "VehicleModelId", c => c.Int(nullable: false));
            CreateIndex("dbo.VehicleProperty", "VehicleModelId");
            AddForeignKey("dbo.VehicleProperty", "VehicleModelId", "dbo.VehicleModel", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleProperty", "VehicleModelId", "dbo.VehicleModel");
            DropIndex("dbo.VehicleProperty", new[] { "VehicleModelId" });
            AlterColumn("dbo.VehicleProperty", "VehicleModelId", c => c.Int());
            RenameColumn(table: "dbo.VehicleProperty", name: "VehicleModelId", newName: "VehicleModelEntity_Id");
            CreateIndex("dbo.VehicleProperty", "VehicleModelEntity_Id");
            AddForeignKey("dbo.VehicleProperty", "VehicleModelEntity_Id", "dbo.VehicleModel", "Id");
        }
    }
}
