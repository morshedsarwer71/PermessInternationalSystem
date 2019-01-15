namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastChnag8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SIDocumentDetails", "PONumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SIDocumentDetails", "PONumber");
        }
    }
}
