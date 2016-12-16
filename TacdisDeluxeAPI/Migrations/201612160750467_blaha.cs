namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blaha : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payer", "StreeatAddress", c => c.String());
            AddColumn("dbo.Payer", "ZipCity", c => c.String());
            AddColumn("dbo.Payer", "Country", c => c.String());
            AddColumn("dbo.Salesman", "Company", c => c.String());
            AddColumn("dbo.Salesman", "StreeatAddress", c => c.String());
            AddColumn("dbo.Salesman", "ZipCity", c => c.String());
            AddColumn("dbo.Salesman", "Country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Salesman", "Country");
            DropColumn("dbo.Salesman", "ZipCity");
            DropColumn("dbo.Salesman", "StreeatAddress");
            DropColumn("dbo.Salesman", "Company");
            DropColumn("dbo.Payer", "Country");
            DropColumn("dbo.Payer", "ZipCity");
            DropColumn("dbo.Payer", "StreeatAddress");
        }
    }
}
