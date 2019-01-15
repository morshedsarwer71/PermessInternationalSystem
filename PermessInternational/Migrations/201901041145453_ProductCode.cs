namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductCode : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailsId = c.Int(nullable: false, identity: true),
                        BuyerorderRef = c.String(),
                        OrderDetail = c.String(),
                        DeliveryTypeId = c.Int(nullable: false),
                        ApprovalId = c.Int(nullable: false),
                        Creator = c.Int(nullable: false),
                        ConcernId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailsId);
            
            AddColumn("dbo.ImportGoods", "ProductCode", c => c.String());
            AddColumn("dbo.ProductionOrders", "ProductCode", c => c.String());
            AddColumn("dbo.SIProductDetails", "ProductCode", c => c.String());
            AddColumn("dbo.SRIProductDetails", "ProductCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SRIProductDetails", "ProductCode");
            DropColumn("dbo.SIProductDetails", "ProductCode");
            DropColumn("dbo.ProductionOrders", "ProductCode");
            DropColumn("dbo.ImportGoods", "ProductCode");
            DropTable("dbo.OrderDetails");
        }
    }
}
