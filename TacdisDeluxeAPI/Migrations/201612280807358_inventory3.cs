namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inventory3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkshopInventoryItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkshopId = c.Int(nullable: false),
                        PartId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WorkshopInventoryItem");
        }
    }
}
