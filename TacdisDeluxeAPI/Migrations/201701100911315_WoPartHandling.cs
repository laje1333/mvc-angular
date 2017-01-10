namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WoPartHandling : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Part", "WoKits_Id", "dbo.WorkOrderKits");
            DropForeignKey("dbo.Part", "WoJob_ID", "dbo.WorkOrderJobs");
            DropIndex("dbo.Part", new[] { "WoKits_Id" });
            DropIndex("dbo.Part", new[] { "WoJob_ID" });
            CreateTable(
                "dbo.WoKits_Parts",
                c => new
                    {
                        WoKits_Id = c.Int(nullable: false),
                        PartId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WoKits_Id, t.PartId })
                .ForeignKey("dbo.WorkOrderKits", t => t.WoKits_Id, cascadeDelete: true)
                .ForeignKey("dbo.Part", t => t.PartId, cascadeDelete: true)
                .Index(t => t.WoKits_Id)
                .Index(t => t.PartId);
            
            CreateTable(
                "dbo.WoJob_Parts",
                c => new
                    {
                        WoJob_ID = c.Int(nullable: false),
                        PartId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WoJob_ID, t.PartId })
                .ForeignKey("dbo.WorkOrderJobs", t => t.WoJob_ID, cascadeDelete: true)
                .ForeignKey("dbo.Part", t => t.PartId, cascadeDelete: true)
                .Index(t => t.WoJob_ID)
                .Index(t => t.PartId);
            
            DropColumn("dbo.Part", "WoKits_Id");
            DropColumn("dbo.Part", "WoJob_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Part", "WoJob_ID", c => c.Int());
            AddColumn("dbo.Part", "WoKits_Id", c => c.Int());
            DropForeignKey("dbo.WoJob_Parts", "PartId", "dbo.Part");
            DropForeignKey("dbo.WoJob_Parts", "WoJob_ID", "dbo.WorkOrderJobs");
            DropForeignKey("dbo.WoKits_Parts", "PartId", "dbo.Part");
            DropForeignKey("dbo.WoKits_Parts", "WoKits_Id", "dbo.WorkOrderKits");
            DropIndex("dbo.WoJob_Parts", new[] { "PartId" });
            DropIndex("dbo.WoJob_Parts", new[] { "WoJob_ID" });
            DropIndex("dbo.WoKits_Parts", new[] { "PartId" });
            DropIndex("dbo.WoKits_Parts", new[] { "WoKits_Id" });
            DropTable("dbo.WoJob_Parts");
            DropTable("dbo.WoKits_Parts");
            CreateIndex("dbo.Part", "WoJob_ID");
            CreateIndex("dbo.Part", "WoKits_Id");
            AddForeignKey("dbo.Part", "WoJob_ID", "dbo.WorkOrderJobs", "ID");
            AddForeignKey("dbo.Part", "WoKits_Id", "dbo.WorkOrderKits", "Id");
        }
    }
}
