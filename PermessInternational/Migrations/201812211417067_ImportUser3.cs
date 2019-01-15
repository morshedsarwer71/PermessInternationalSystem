namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImportUser3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImportGoods", "GoodsType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ImportGoods", "GoodsType");
        }
    }
}
