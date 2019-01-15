namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class massinveChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MachinePurchases",
                c => new
                    {
                        MachinePurchaseId = c.Int(nullable: false, identity: true),
                        MachineName = c.String(),
                        Specification = c.String(),
                        Quantity = c.Int(nullable: false),
                        Retension = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        ConcernId = c.Int(nullable: false),
                        Creator = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MachinePurchaseId);
            
            CreateTable(
                "dbo.SRIProductDetails",
                c => new
                    {
                        SRIProductDetId = c.Int(nullable: false, identity: true),
                        SRICode = c.String(),
                        ProductId = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                        AltArticle = c.String(),
                        WidthId = c.Int(nullable: false),
                        ConstructionId = c.Int(nullable: false),
                        SoftnessId = c.Int(nullable: false),
                        SourceId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                        LenghtId = c.Int(nullable: false),
                        OrderQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliveryQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OverInvoice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsConfirmed = c.Int(nullable: false),
                        Description = c.String(),
                        ConcernId = c.Int(nullable: false),
                        Creator = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SRIProductDetId);
            
            AddColumn("dbo.ProductionOrders", "AssignTo", c => c.Int(nullable: false));
            DropColumn("dbo.ProductionOrders", "UserRoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductionOrders", "UserRoleId", c => c.Int(nullable: false));
            DropColumn("dbo.ProductionOrders", "AssignTo");
            DropTable("dbo.SRIProductDetails");
            DropTable("dbo.MachinePurchases");
        }
    }
}
