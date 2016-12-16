namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20161216_0800 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sale", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sale", "DateEdited", c => c.DateTime(nullable: false));
            AddColumn("dbo.Payer", "CustomerNumber", c => c.String());
            AddColumn("dbo.VehicleProperty", "Field", c => c.String());
            AddColumn("dbo.VehicleProperty", "ParentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VehicleProperty", "ParentId");
            DropColumn("dbo.VehicleProperty", "Field");
            DropColumn("dbo.Payer", "CustomerNumber");
            DropColumn("dbo.Sale", "DateEdited");
            DropColumn("dbo.Sale", "DateCreated");
        }
    }
}
