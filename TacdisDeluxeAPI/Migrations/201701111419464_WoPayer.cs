namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WoPayer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkOrder", "MainPayer_Id", c => c.Int());
            AddColumn("dbo.WorkOrder", "RespBy_Id", c => c.Int());
            CreateIndex("dbo.WorkOrder", "MainPayer_Id");
            CreateIndex("dbo.WorkOrder", "RespBy_Id");
            AddForeignKey("dbo.WorkOrder", "MainPayer_Id", "dbo.Payer", "Id");
            AddForeignKey("dbo.WorkOrder", "RespBy_Id", "dbo.Salesman", "Id");
            DropColumn("dbo.WorkOrder", "MainPayer");
            DropColumn("dbo.WorkOrder", "RespBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkOrder", "RespBy", c => c.String());
            AddColumn("dbo.WorkOrder", "MainPayer", c => c.String());
            DropForeignKey("dbo.WorkOrder", "RespBy_Id", "dbo.Salesman");
            DropForeignKey("dbo.WorkOrder", "MainPayer_Id", "dbo.Payer");
            DropIndex("dbo.WorkOrder", new[] { "RespBy_Id" });
            DropIndex("dbo.WorkOrder", new[] { "MainPayer_Id" });
            DropColumn("dbo.WorkOrder", "RespBy_Id");
            DropColumn("dbo.WorkOrder", "MainPayer_Id");
        }
    }
}
