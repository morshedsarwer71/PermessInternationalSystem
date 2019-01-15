namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class massinveChange8454 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductionProcesses",
                c => new
                    {
                        ProductionProcessId = c.Int(nullable: false, identity: true),
                        ProductionOrderId = c.Int(nullable: false),
                        OpeninBalanceA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OpeninBalanceB = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OpeninBalanceC = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReceivFromWHouse = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReceivFromA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReceivFromB = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Used = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GradeA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProcessLossA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProcessLossB = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GradeB = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GradeD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Refund = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReadyToUse = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GradeC = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SendB = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SendFinal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClosingA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RejectedFinal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Final = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductionProcessId);
            
            AlterColumn("dbo.ProductionOrders", "AssignedTime", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductionOrders", "AssignedTime", c => c.Int(nullable: false));
            DropTable("dbo.ProductionProcesses");
        }
    }
}
