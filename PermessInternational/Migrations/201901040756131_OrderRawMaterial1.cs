namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderRawMaterial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderRawMaterials", "OrderId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderRawMaterials", "OrderId");
        }
    }
}
