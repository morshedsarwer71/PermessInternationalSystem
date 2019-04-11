namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SIProductDetailsIdh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeliveryQuantities", "SIProductDetailsCode", c => c.String());
            DropColumn("dbo.DeliveryQuantities", "SIProductDetailsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeliveryQuantities", "SIProductDetailsId", c => c.Int(nullable: false));
            DropColumn("dbo.DeliveryQuantities", "SIProductDetailsCode");
        }
    }
}
