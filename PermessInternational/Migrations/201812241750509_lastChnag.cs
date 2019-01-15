namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastChnag : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CashDetails",
                c => new
                    {
                        CashDetailsId = c.Int(nullable: false, identity: true),
                        SICode = c.String(),
                        BillNo = c.Int(nullable: false),
                        BillingDate = c.DateTime(nullable: false),
                        TotalReceived = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChalanInfo = c.String(),
                        FromDestination = c.String(),
                        ToDestination = c.String(),
                        USD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ComissionUSD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        ConcernId = c.Int(nullable: false),
                        Creator = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CashDetailsId);
            
            CreateTable(
                "dbo.ExportIssues",
                c => new
                    {
                        ExportIssueId = c.Int(nullable: false, identity: true),
                        FileNo = c.String(),
                        SiCode = c.String(),
                        ExpoNumber = c.String(),
                        ExpoIssueDate = c.DateTime(nullable: false),
                        ExpoSentDate = c.DateTime(nullable: false),
                        ExpoReceivedDate = c.DateTime(nullable: false),
                        IPDate = c.DateTime(nullable: false),
                        UPDate = c.DateTime(nullable: false),
                        PartyName = c.String(),
                        RegionId = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BankSubmitDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        RealizeDate = c.DateTime(nullable: false),
                        CollectionDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        ConcernId = c.Int(nullable: false),
                        Creator = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ExportIssueId);
            
            CreateTable(
                "dbo.LCStatements",
                c => new
                    {
                        LCStatementId = c.Int(nullable: false, identity: true),
                        SICode = c.String(),
                        LCNumber = c.String(),
                        LCDate = c.DateTime(nullable: false),
                        ExpiraionDate = c.DateTime(nullable: false),
                        RealiseValue = c.String(),
                        LCStatus = c.Int(nullable: false),
                        HSCode = c.String(),
                        FileNo = c.String(),
                        ShipmentDate = c.DateTime(nullable: false),
                        Tenor = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comission = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BankName = c.String(),
                        BankSubDate = c.DateTime(nullable: false),
                        PartyName = c.String(),
                        PaymentClause = c.Int(nullable: false),
                        Description = c.String(),
                        ConcernId = c.Int(nullable: false),
                        Creator = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LCStatementId);
            
            CreateTable(
                "dbo.ProductionOrders",
                c => new
                    {
                        ProductionOrderId = c.Int(nullable: false, identity: true),
                        SICode = c.String(),
                        ProductId = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                        AltArticleId = c.Int(nullable: false),
                        WidthId = c.Int(nullable: false),
                        ConstructionId = c.Int(nullable: false),
                        SoftnessId = c.Int(nullable: false),
                        SourceId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                        RequiredAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProcessType = c.Int(nullable: false),
                        AssignedTime = c.Int(nullable: false),
                        UserRoleId = c.Int(nullable: false),
                        ProductionStatus = c.Int(nullable: false),
                        Description = c.String(),
                        ConcernId = c.Int(nullable: false),
                        Creator = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductionOrderId);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        RegionId = c.Int(nullable: false, identity: true),
                        RegionName = c.String(),
                        Description = c.String(),
                        ConcernId = c.Int(nullable: false),
                        Creator = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RegionId);
            
            AddColumn("dbo.SIDocumentDetails", "CompanyId", c => c.Int(nullable: false));
            AddColumn("dbo.SIDocumentDetails", "ApprovedStatus", c => c.Int(nullable: false));
            AddColumn("dbo.SIDocumentDetails", "BuyerOrderRef", c => c.String());
            AddColumn("dbo.SIDocumentDetails", "OrderDetails", c => c.String());
            AddColumn("dbo.SIDocumentDetails", "Description", c => c.String());
            AddColumn("dbo.SIProductDetails", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SIProductDetails", "Description");
            DropColumn("dbo.SIDocumentDetails", "Description");
            DropColumn("dbo.SIDocumentDetails", "OrderDetails");
            DropColumn("dbo.SIDocumentDetails", "BuyerOrderRef");
            DropColumn("dbo.SIDocumentDetails", "ApprovedStatus");
            DropColumn("dbo.SIDocumentDetails", "CompanyId");
            DropTable("dbo.Regions");
            DropTable("dbo.ProductionOrders");
            DropTable("dbo.LCStatements");
            DropTable("dbo.ExportIssues");
            DropTable("dbo.CashDetails");
        }
    }
}
