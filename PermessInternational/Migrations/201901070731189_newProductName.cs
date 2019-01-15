namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newProductName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductNames",
                c => new
                    {
                        ProductNameId = c.Int(nullable: false, identity: true),
                        ProductCode = c.String(),
                        ProductId = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                        AltArticleId = c.String(),
                        WidthId = c.Int(nullable: false),
                        ConstructionId = c.Int(nullable: false),
                        SoftnessId = c.Int(nullable: false),
                        SourceId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductNameId);
            
            AddColumn("dbo.ProductionProcessAs", "ClosingBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ProductionProcessBs", "ClosingBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductionProcessBs", "ClosingBalance");
            DropColumn("dbo.ProductionProcessAs", "ClosingBalance");
            DropTable("dbo.ProductNames");
        }
    }
}
