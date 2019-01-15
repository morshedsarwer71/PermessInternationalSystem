namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImportUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImportGoods",
                c => new
                    {
                        ImportGoodId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                        AltArticleId = c.String(),
                        WidthId = c.Int(nullable: false),
                        ConstructionId = c.Int(nullable: false),
                        SoftnessId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        ReceivedDate = c.DateTime(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PerformaCode = c.String(),
                        LCNumber = c.String(),
                        Supplier = c.String(),
                        ConcernId = c.Int(nullable: false),
                        Creator = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ImportGoodId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImportGoods");
        }
    }
}
