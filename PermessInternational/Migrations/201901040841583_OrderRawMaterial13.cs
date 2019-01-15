namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderRawMaterial13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderRawMaterials", "ProductCode", c => c.String());
            DropColumn("dbo.OrderRawMaterials", "Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderRawMaterials", "Code", c => c.Int(nullable: false));
            DropColumn("dbo.OrderRawMaterials", "ProductCode");
        }
    }
}
