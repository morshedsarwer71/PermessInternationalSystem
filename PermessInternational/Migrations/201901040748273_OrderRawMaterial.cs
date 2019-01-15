namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderRawMaterial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderRawMaterials",
                c => new
                    {
                        OrderRawMaterialId = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                        AltArticle = c.String(),
                        WidthId = c.Int(nullable: false),
                        ConstructionId = c.Int(nullable: false),
                        SoftnessId = c.Int(nullable: false),
                        SourceId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                        LenghtId = c.Int(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        ConcernId = c.Int(nullable: false),
                        Creator = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderRawMaterialId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OrderRawMaterials");
        }
    }
}
