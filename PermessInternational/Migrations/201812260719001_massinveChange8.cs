namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class massinveChange8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SRIProductDetails", "SRIDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SRIProductDetails", "SICode", c => c.String());
            DropColumn("dbo.SRIProductDetails", "SIRDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SRIProductDetails", "SIRDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.SRIProductDetails", "SICode");
            DropColumn("dbo.SRIProductDetails", "SRIDate");
        }
    }
}
