namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class byteAvTyper : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoice", "InvoiceState", c => c.Int(nullable: false));
            AlterColumn("dbo.Invoice", "DueDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Invoice", "InvoiceDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoice", "InvoiceDate", c => c.String());
            AlterColumn("dbo.Invoice", "DueDate", c => c.String());
            AlterColumn("dbo.Invoice", "InvoiceState", c => c.String(nullable: false));
        }
    }
}
