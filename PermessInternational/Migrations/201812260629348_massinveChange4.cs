namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class massinveChange4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SRIProductDetails", "SIRDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SRIProductDetails", "SIRDate");
        }
    }
}
