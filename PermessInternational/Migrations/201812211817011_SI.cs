namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SI : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SIDocumentDetails",
                c => new
                    {
                        SIDocumentDetId = c.Int(nullable: false, identity: true),
                        SICode = c.String(),
                        IssueDate = c.DateTime(nullable: false),
                        IssuedBy = c.String(),
                        SIName = c.String(),
                        DeliveryStatus = c.Int(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        ItemNo = c.String(),
                        DeliveryType = c.Int(nullable: false),
                        Buyer = c.String(),
                        PaymentMethod = c.Int(nullable: false),
                        Bank = c.Int(nullable: false),
                        DocumentStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SIDocumentDetId);
            
            CreateTable(
                "dbo.SIProductDetails",
                c => new
                    {
                        SIProductDetId = c.Int(nullable: false, identity: true),
                        SICode = c.String(),
                        ProductId = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                        AltArticle = c.String(),
                        WidthId = c.Int(nullable: false),
                        ConstructionId = c.Int(nullable: false),
                        SoftnessId = c.Int(nullable: false),
                        SourceId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                        Lenght = c.Int(nullable: false),
                        OrderQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliveryQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OverInvoice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsConfirmed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SIProductDetId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SIProductDetails");
            DropTable("dbo.SIDocumentDetails");
        }
    }
}
