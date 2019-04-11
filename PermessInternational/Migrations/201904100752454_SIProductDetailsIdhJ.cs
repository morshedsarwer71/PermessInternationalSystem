namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SIProductDetailsIdhJ : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SIProductDetails", "SIProductDetailsCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SIProductDetails", "SIProductDetailsCode");
        }
    }
}
