namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productionAndProcessChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductionProcessAs", "ThirdPartyStatus", c => c.Int(nullable: false));
            AddColumn("dbo.ProductionProcessBs", "ThirdPartyStatus", c => c.Int(nullable: false));
            AddColumn("dbo.ProductionProcessCs", "ThirdPartyStatus", c => c.Int(nullable: false));
            AddColumn("dbo.ProductionOrders", "ThirdPartyStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductionOrders", "ThirdPartyStatus");
            DropColumn("dbo.ProductionProcessCs", "ThirdPartyStatus");
            DropColumn("dbo.ProductionProcessBs", "ThirdPartyStatus");
            DropColumn("dbo.ProductionProcessAs", "ThirdPartyStatus");
        }
    }
}
