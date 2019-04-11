namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocsSubmitDate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PIReviseds", "PICode", c => c.String());
            AddColumn("dbo.PIReviseds", "ConcernId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PIReviseds", "ConcernId");
            DropColumn("dbo.PIReviseds", "PICode");
        }
    }
}
