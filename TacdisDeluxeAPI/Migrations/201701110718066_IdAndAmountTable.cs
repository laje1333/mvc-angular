namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdAndAmountTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IdAndAmount",
                c => new
                    {
                        TableID = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        WoJob_ID = c.Int(),
                    })
                .PrimaryKey(t => t.TableID)
                .ForeignKey("dbo.WorkOrderJobs", t => t.WoJob_ID)
                .Index(t => t.WoJob_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdAndAmount", "WoJob_ID", "dbo.WorkOrderJobs");
            DropIndex("dbo.IdAndAmount", new[] { "WoJob_ID" });
            DropTable("dbo.IdAndAmount");
        }
    }
}
