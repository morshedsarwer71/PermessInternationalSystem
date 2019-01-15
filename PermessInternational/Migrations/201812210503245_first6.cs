namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "CreationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductSettings", "CreationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductSettings", "CreationDate", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "CreationDate", c => c.Int(nullable: false));
        }
    }
}
