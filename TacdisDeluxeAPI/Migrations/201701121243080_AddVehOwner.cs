namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehOwner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payer", "PhoneNr", c => c.String());
            AddColumn("dbo.Vehicle", "RegistrationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehicle", "Milage", c => c.Double(nullable: false));
            AddColumn("dbo.Vehicle", "LastServiceDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehicle", "Owner_Id", c => c.Int());
            CreateIndex("dbo.Vehicle", "Owner_Id");
            AddForeignKey("dbo.Vehicle", "Owner_Id", "dbo.Payer", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicle", "Owner_Id", "dbo.Payer");
            DropIndex("dbo.Vehicle", new[] { "Owner_Id" });
            DropColumn("dbo.Vehicle", "Owner_Id");
            DropColumn("dbo.Vehicle", "LastServiceDate");
            DropColumn("dbo.Vehicle", "Milage");
            DropColumn("dbo.Vehicle", "RegistrationDate");
            DropColumn("dbo.Payer", "PhoneNr");
        }
    }
}
