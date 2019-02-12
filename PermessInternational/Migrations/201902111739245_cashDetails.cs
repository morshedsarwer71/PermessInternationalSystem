namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cashDetails : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CashDetails", "FromDestination", c => c.Int(nullable: false));
            AlterColumn("dbo.CashDetails", "ToDestination", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CashDetails", "ToDestination", c => c.String());
            AlterColumn("dbo.CashDetails", "FromDestination", c => c.String());
        }
    }
}
