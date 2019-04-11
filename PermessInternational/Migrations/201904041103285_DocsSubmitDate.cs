namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocsSubmitDate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PIReviseds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RevisedDate = c.DateTime(nullable: false),
                        RevisedDocs = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.LCStatements", "DocumentSubDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.LCStatements", "DocumentExpDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LCStatements", "DocumentExpDate");
            DropColumn("dbo.LCStatements", "DocumentSubDate");
            DropTable("dbo.PIReviseds");
        }
    }
}
