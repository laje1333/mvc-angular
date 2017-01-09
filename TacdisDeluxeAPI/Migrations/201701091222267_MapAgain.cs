namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MapAgain : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Salesman", new[] { "EmployeeNumber" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Salesman", "EmployeeNumber", unique: true);
        }
    }
}
