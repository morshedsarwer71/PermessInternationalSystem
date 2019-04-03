namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newUpdateforProforma : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Buyer", c => c.String());
            AddColumn("dbo.SIDocumentDetails", "GoodsReqDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SIDocumentDetails", "GoodsReqDate");
            DropColumn("dbo.Companies", "Buyer");
        }
    }
}
