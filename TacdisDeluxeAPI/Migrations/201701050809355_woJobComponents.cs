namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class woJobComponents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkOrderKits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WJKCode = c.Int(nullable: false),
                        KitType = c.String(),
                        KitDesc = c.String(),
                        Quantity = c.Double(nullable: false),
                        TotCost = c.Double(nullable: false),
                        WoJob_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkOrderJobs", t => t.WoJob_ID)
                .Index(t => t.WoJob_ID);
            
            CreateTable(
                "dbo.WorkOrderOperations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OPNr = c.Int(nullable: false),
                        OPDesc = c.String(),
                        Quantity = c.Double(nullable: false),
                        WorkTime = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        WoJob_ID = c.Int(),
                        WoKits_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkOrderJobs", t => t.WoJob_ID)
                .ForeignKey("dbo.WorkOrderKits", t => t.WoKits_Id)
                .Index(t => t.WoJob_ID)
                .Index(t => t.WoKits_Id);
            
            AddColumn("dbo.Part", "WoJob_ID", c => c.Int());
            AddColumn("dbo.Part", "WoKits_Id", c => c.Int());
            CreateIndex("dbo.Part", "WoJob_ID");
            CreateIndex("dbo.Part", "WoKits_Id");
            AddForeignKey("dbo.Part", "WoJob_ID", "dbo.WorkOrderJobs", "ID");
            AddForeignKey("dbo.Part", "WoKits_Id", "dbo.WorkOrderKits", "Id");
            DropColumn("dbo.WorkOrderJobs", "WoHNr");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkOrderJobs", "WoHNr", c => c.Int(nullable: false));
            DropForeignKey("dbo.WorkOrderOperations", "WoKits_Id", "dbo.WorkOrderKits");
            DropForeignKey("dbo.WorkOrderOperations", "WoJob_ID", "dbo.WorkOrderJobs");
            DropForeignKey("dbo.Part", "WoKits_Id", "dbo.WorkOrderKits");
            DropForeignKey("dbo.WorkOrderKits", "WoJob_ID", "dbo.WorkOrderJobs");
            DropForeignKey("dbo.Part", "WoJob_ID", "dbo.WorkOrderJobs");
            DropIndex("dbo.WorkOrderOperations", new[] { "WoKits_Id" });
            DropIndex("dbo.WorkOrderOperations", new[] { "WoJob_ID" });
            DropIndex("dbo.WorkOrderKits", new[] { "WoJob_ID" });
            DropIndex("dbo.Part", new[] { "WoKits_Id" });
            DropIndex("dbo.Part", new[] { "WoJob_ID" });
            DropColumn("dbo.Part", "WoKits_Id");
            DropColumn("dbo.Part", "WoJob_ID");
            DropTable("dbo.WorkOrderOperations");
            DropTable("dbo.WorkOrderKits");
        }
    }
}
