namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SI2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SIDocumentDetails", "DeliveryAddress", c => c.String());
            AddColumn("dbo.SIDocumentDetails", "Revised", c => c.Int(nullable: false));
            AddColumn("dbo.SIDocumentDetails", "CommisionStatus", c => c.Int(nullable: false));
            AddColumn("dbo.SIDocumentDetails", "CommisionAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.SIDocumentDetails", "LCStatus", c => c.Int(nullable: false));
            AddColumn("dbo.SIDocumentDetails", "HSCode", c => c.String());
            AddColumn("dbo.SIDocumentDetails", "ConcernId", c => c.Int(nullable: false));
            AddColumn("dbo.SIDocumentDetails", "Creator", c => c.Int(nullable: false));
            AddColumn("dbo.SIDocumentDetails", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SIProductDetails", "ConcernId", c => c.Int(nullable: false));
            AddColumn("dbo.SIProductDetails", "Creator", c => c.Int(nullable: false));
            AddColumn("dbo.SIProductDetails", "CreationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SIProductDetails", "CreationDate");
            DropColumn("dbo.SIProductDetails", "Creator");
            DropColumn("dbo.SIProductDetails", "ConcernId");
            DropColumn("dbo.SIDocumentDetails", "CreationDate");
            DropColumn("dbo.SIDocumentDetails", "Creator");
            DropColumn("dbo.SIDocumentDetails", "ConcernId");
            DropColumn("dbo.SIDocumentDetails", "HSCode");
            DropColumn("dbo.SIDocumentDetails", "LCStatus");
            DropColumn("dbo.SIDocumentDetails", "CommisionAmount");
            DropColumn("dbo.SIDocumentDetails", "CommisionStatus");
            DropColumn("dbo.SIDocumentDetails", "Revised");
            DropColumn("dbo.SIDocumentDetails", "DeliveryAddress");
        }
    }
}
