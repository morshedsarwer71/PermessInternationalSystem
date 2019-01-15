namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastChnag4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SIDocumentDetails", "ContactPerson", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SIDocumentDetails", "ContactPerson");
        }
    }
}
