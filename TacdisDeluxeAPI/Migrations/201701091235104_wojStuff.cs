namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wojStuff : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Sale", name: "Sale_Id", newName: "Salesman_Id");
            RenameIndex(table: "dbo.Sale", name: "IX_Sale_Id", newName: "IX_Salesman_Id");
            AddColumn("dbo.WorkOrderJobs", "PayerName", c => c.String());
            CreateIndex("dbo.Salesman", "EmployeeNumber", unique: true);
            DropColumn("dbo.WorkOrderJobs", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkOrderJobs", "Name", c => c.String());
            DropIndex("dbo.Salesman", new[] { "EmployeeNumber" });
            DropColumn("dbo.WorkOrderJobs", "PayerName");
            RenameIndex(table: "dbo.Sale", name: "IX_Salesman_Id", newName: "IX_Sale_Id");
            RenameColumn(table: "dbo.Sale", name: "Salesman_Id", newName: "Sale_Id");
        }
    }
}
