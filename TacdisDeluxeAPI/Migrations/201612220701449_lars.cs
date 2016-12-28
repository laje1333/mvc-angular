namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lars : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkOrder",
                c => new
                    {
                        WoNr = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        RegNr = c.String(),
                        VehDesc = c.String(),
                        VehRegDate = c.DateTime(nullable: false),
                        VehOwner = c.String(),
                        VehDriver = c.String(),
                        VehPhoneNr = c.String(),
                        VehLastVisDate = c.DateTime(nullable: false),
                        VehLastVisMil = c.String(),
                        CurrentMilage = c.Double(nullable: false),
                        PlannedMechID = c.Int(nullable: false),
                        PlannedMechName = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        PlannedDate = c.DateTime(nullable: false),
                        CheckedInDate = c.DateTime(nullable: false),
                        MainPayer = c.String(),
                        RespBy = c.String(),
                        TotCost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.WoNr);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WorkOrder");
        }
    }
}
