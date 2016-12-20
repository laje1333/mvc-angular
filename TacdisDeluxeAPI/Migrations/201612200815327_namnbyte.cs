namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namnbyte : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Payer", "FirsName", "FirstName");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Payer", "FirstName", "FirsName");
        }
    }
}
