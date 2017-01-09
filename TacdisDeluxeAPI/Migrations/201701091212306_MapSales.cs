namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MapSales : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Sale", name: "Salesman_Id", newName: "Sale_Id");
            RenameIndex(table: "dbo.Sale", name: "IX_Salesman_Id", newName: "IX_Sale_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Sale", name: "IX_Sale_Id", newName: "IX_Salesman_Id");
            RenameColumn(table: "dbo.Sale", name: "Sale_Id", newName: "Salesman_Id");
        }
    }
}
