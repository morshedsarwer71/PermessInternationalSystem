namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hdhfd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductionOrders", "GoodsType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductionOrders", "GoodsType");
        }
    }
}
