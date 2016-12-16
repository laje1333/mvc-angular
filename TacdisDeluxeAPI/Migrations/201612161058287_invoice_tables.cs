namespace TacdisDeluxeAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invoice_tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceRow",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Item = c.String(),
                        Description = c.String(),
                        UnitCost = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Vat = c.Double(nullable: false),
                        InvoiceRowAmount = c.Double(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoice", t => t.InvoiceId, cascadeDelete: true)
                .Index(t => t.InvoiceId);
            
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceNumber = c.Int(nullable: false),
                        InvoiceState = c.String(nullable: false),
                        DueDate = c.String(),
                        InvoiceDate = c.String(),
                        InvoiceAmount = c.Double(nullable: false),
                        DebitCredit = c.String(),
                        Vat = c.Double(nullable: false),
                        AmountPaid = c.Double(nullable: false),
                        WoNumber = c.Int(nullable: false),
                        JobNumber = c.String(),
                        RegNumber = c.String(),
                        Payer_Id = c.Int(nullable: false),
                        Salesman_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Payer", t => t.Payer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Salesman", t => t.Salesman_Id, cascadeDelete: true)
                .Index(t => t.InvoiceNumber, unique: true)
                .Index(t => t.Payer_Id)
                .Index(t => t.Salesman_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoice", "Salesman_Id", "dbo.Salesman");
            DropForeignKey("dbo.Invoice", "Payer_Id", "dbo.Payer");
            DropForeignKey("dbo.InvoiceRow", "InvoiceId", "dbo.Invoice");
            DropIndex("dbo.Invoice", new[] { "Salesman_Id" });
            DropIndex("dbo.Invoice", new[] { "Payer_Id" });
            DropIndex("dbo.Invoice", new[] { "InvoiceNumber" });
            DropIndex("dbo.InvoiceRow", new[] { "InvoiceId" });
            DropTable("dbo.Invoice");
            DropTable("dbo.InvoiceRow");
        }
    }
}
