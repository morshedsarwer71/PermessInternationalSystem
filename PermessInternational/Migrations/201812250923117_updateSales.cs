namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSales : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SIDocumentDetails", "Style", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SIDocumentDetails", "Style");
        }
    }
}
