namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class woMap2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkOrderOperations", "WoJob_ID", "dbo.WorkOrderJobs");
            DropIndex("dbo.WorkOrderOperations", new[] { "WoJob_ID" });
            AlterColumn("dbo.WorkOrderOperations", "WoJob_ID", c => c.Int());
            CreateIndex("dbo.WorkOrderOperations", "WoJob_ID");
            AddForeignKey("dbo.WorkOrderOperations", "WoJob_ID", "dbo.WorkOrderJobs", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkOrderOperations", "WoJob_ID", "dbo.WorkOrderJobs");
            DropIndex("dbo.WorkOrderOperations", new[] { "WoJob_ID" });
            AlterColumn("dbo.WorkOrderOperations", "WoJob_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.WorkOrderOperations", "WoJob_ID");
            AddForeignKey("dbo.WorkOrderOperations", "WoJob_ID", "dbo.WorkOrderJobs", "ID", cascadeDelete: true);
        }
    }
}
