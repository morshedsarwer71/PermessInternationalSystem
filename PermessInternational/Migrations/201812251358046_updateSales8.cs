namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSales8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SIProductDetails", "LenghtId", c => c.Int(nullable: false));
            DropColumn("dbo.SIProductDetails", "Lenght");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SIProductDetails", "Lenght", c => c.Int(nullable: false));
            DropColumn("dbo.SIProductDetails", "LenghtId");
        }
    }
}
