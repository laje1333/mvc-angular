namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invoice_stuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salesman", "EmployeeNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Payer", "CustomerNumber", c => c.Int(nullable: false));
            CreateIndex("dbo.Payer", "CustomerNumber", unique: true);
            CreateIndex("dbo.Salesman", "EmployeeNumber", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Salesman", new[] { "EmployeeNumber" });
            DropIndex("dbo.Payer", new[] { "CustomerNumber" });
            AlterColumn("dbo.Payer", "CustomerNumber", c => c.String());
            DropColumn("dbo.Salesman", "EmployeeNumber");
        }
    }
}
