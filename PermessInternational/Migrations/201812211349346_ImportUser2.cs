namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImportUser2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImportGoods", "ColorId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ImportGoods", "ColorId");
        }
    }
}
