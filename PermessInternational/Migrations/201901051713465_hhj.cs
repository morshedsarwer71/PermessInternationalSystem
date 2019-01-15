namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hhj : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderRawMaterials", "IsProcess", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderRawMaterials", "IsProcess");
        }
    }
}
