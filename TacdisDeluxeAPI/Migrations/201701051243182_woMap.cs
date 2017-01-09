namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class woMap : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkOrderJobs", "WorkOrder_WoNr", "dbo.WorkOrder");
            DropForeignKey("dbo.WorkOrderKits", "WoJob_ID", "dbo.WorkOrderJobs");
            DropForeignKey("dbo.WorkOrderOperations", "WoJob_ID", "dbo.WorkOrderJobs");
            DropIndex("dbo.WorkOrderJobs", new[] { "WorkOrder_WoNr" });
            DropIndex("dbo.WorkOrderKits", new[] { "WoJob_ID" });
            DropIndex("dbo.WorkOrderOperations", new[] { "WoJob_ID" });
            AddColumn("dbo.WorkOrder", "isCheckedIn", c => c.Boolean(nullable: false));
            AlterColumn("dbo.WorkOrderJobs", "WorkOrder_WoNr", c => c.Int(nullable: false));
            AlterColumn("dbo.WorkOrderKits", "WoJob_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.WorkOrderOperations", "WoJob_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.WorkOrderJobs", "WorkOrder_WoNr");
            CreateIndex("dbo.WorkOrderKits", "WoJob_ID");
            CreateIndex("dbo.WorkOrderOperations", "WoJob_ID");
            AddForeignKey("dbo.WorkOrderJobs", "WorkOrder_WoNr", "dbo.WorkOrder", "WoNr", cascadeDelete: true);
            AddForeignKey("dbo.WorkOrderKits", "WoJob_ID", "dbo.WorkOrderJobs", "ID", cascadeDelete: true);
            AddForeignKey("dbo.WorkOrderOperations", "WoJob_ID", "dbo.WorkOrderJobs", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkOrderOperations", "WoJob_ID", "dbo.WorkOrderJobs");
            DropForeignKey("dbo.WorkOrderKits", "WoJob_ID", "dbo.WorkOrderJobs");
            DropForeignKey("dbo.WorkOrderJobs", "WorkOrder_WoNr", "dbo.WorkOrder");
            DropIndex("dbo.WorkOrderOperations", new[] { "WoJob_ID" });
            DropIndex("dbo.WorkOrderKits", new[] { "WoJob_ID" });
            DropIndex("dbo.WorkOrderJobs", new[] { "WorkOrder_WoNr" });
            AlterColumn("dbo.WorkOrderOperations", "WoJob_ID", c => c.Int());
            AlterColumn("dbo.WorkOrderKits", "WoJob_ID", c => c.Int());
            AlterColumn("dbo.WorkOrderJobs", "WorkOrder_WoNr", c => c.Int());
            DropColumn("dbo.WorkOrder", "isCheckedIn");
            CreateIndex("dbo.WorkOrderOperations", "WoJob_ID");
            CreateIndex("dbo.WorkOrderKits", "WoJob_ID");
            CreateIndex("dbo.WorkOrderJobs", "WorkOrder_WoNr");
            AddForeignKey("dbo.WorkOrderOperations", "WoJob_ID", "dbo.WorkOrderJobs", "ID");
            AddForeignKey("dbo.WorkOrderKits", "WoJob_ID", "dbo.WorkOrderJobs", "ID");
            AddForeignKey("dbo.WorkOrderJobs", "WorkOrder_WoNr", "dbo.WorkOrder", "WoNr");
        }
    }
}
