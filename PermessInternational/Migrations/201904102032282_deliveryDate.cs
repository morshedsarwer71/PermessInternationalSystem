namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deliveryDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeliveryQuantities", "DeliveryDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeliveryQuantities", "DeliveryDate");
        }
    }
}
