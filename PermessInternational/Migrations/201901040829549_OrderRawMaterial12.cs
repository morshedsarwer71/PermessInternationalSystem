namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderRawMaterial12 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderRawMaterials", "LenghtId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderRawMaterials", "LenghtId", c => c.Int(nullable: false));
        }
    }
}
