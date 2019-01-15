namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class massinveChange88 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductionOrders", "IsProcess", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductionOrders", "IsProcess");
        }
    }
}
