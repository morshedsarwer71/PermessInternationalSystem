namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class expectedPaymentDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SIDocumentDetails", "ExpectedPaymentDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SIDocumentDetails", "ExpectedPaymentExpDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SIDocumentDetails", "ExpectedPaymentExpDate");
            DropColumn("dbo.SIDocumentDetails", "ExpectedPaymentDate");
        }
    }
}
