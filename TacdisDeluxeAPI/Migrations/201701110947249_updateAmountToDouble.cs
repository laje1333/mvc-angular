namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAmountToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IdAndAmount", "Amount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IdAndAmount", "Amount", c => c.Int(nullable: false));
        }
    }
}
