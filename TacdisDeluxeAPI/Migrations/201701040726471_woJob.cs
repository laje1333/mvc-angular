namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class woJob : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkOrderJobs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WoHNr = c.Int(nullable: false),
                        WoJNr = c.Int(nullable: false),
                        Status = c.String(),
                        TotCost = c.Double(nullable: false),
                        JobDoneDate = c.DateTime(nullable: false),
                        PayerCustNr = c.Int(nullable: false),
                        Alias = c.String(),
                        AddressType = c.String(),
                        AddressFull = c.String(),
                        Name = c.String(),
                        FirstName = c.String(),
                        Contact = c.String(),
                        PaymentMethod = c.String(),
                        FixedPrice = c.Double(nullable: false),
                        VatPerc = c.Double(nullable: false),
                        RefNo = c.String(),
                        RefNoExtra = c.String(),
                        ProfCentreID = c.String(),
                        ProfCentreName = c.String(),
                        WorkOrder_WoNr = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.WorkOrder", t => t.WorkOrder_WoNr)
                .Index(t => t.WorkOrder_WoNr);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkOrderJobs", "WorkOrder_WoNr", "dbo.WorkOrder");
            DropIndex("dbo.WorkOrderJobs", new[] { "WorkOrder_WoNr" });
            DropTable("dbo.WorkOrderJobs");
        }
    }
}
