namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wojStuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkOrderJobs", "PayerName", c => c.String());
            DropColumn("dbo.WorkOrderJobs", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkOrderJobs", "Name", c => c.String());
            DropColumn("dbo.WorkOrderJobs", "PayerName");
        }
    }
}
