namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class massinveChange87 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductionOrders", "AltArticleId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductionOrders", "AltArticleId", c => c.Int(nullable: false));
        }
    }
}
