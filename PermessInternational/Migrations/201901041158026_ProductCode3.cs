namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductCode3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "SICode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "SICode");
        }
    }
}
