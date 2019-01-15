namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newProductName44 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeliveryQuantities",
                c => new
                    {
                        DeliveryQuantityID = c.Int(nullable: false, identity: true),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductCode = c.String(),
                        ConcernId = c.Int(nullable: false),
                        Creator = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.DeliveryQuantityID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DeliveryQuantities");
        }
    }
}
