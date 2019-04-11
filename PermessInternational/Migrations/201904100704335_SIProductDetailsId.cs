namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SIProductDetailsId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeliveryQuantities", "SIProductDetailsId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeliveryQuantities", "SIProductDetailsId");
        }
    }
}
