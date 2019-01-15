namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class process2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductionProcessAs",
                c => new
                    {
                        ProcessAId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        OpeninBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReceivFromWHouse = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Used = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProcessLoss = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Refund = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SendB = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Creator = c.Int(nullable: false),
                        ConcernId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProcessAId);
            
            CreateTable(
                "dbo.ProductionProcessBs",
                c => new
                    {
                        ProcessBId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        OpeninBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReceivFromA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProcessLoss = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReadyToUse = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SendFinal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Creator = c.Int(nullable: false),
                        ConcernId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProcessBId);
            
            CreateTable(
                "dbo.ProductionProcessCs",
                c => new
                    {
                        ProcessCId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        OpeninBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReceivFromB = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GradeA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GradeB = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GradeC = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GradeD = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Refected = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SenDFinal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsFinal = c.Int(nullable: false),
                        Creator = c.Int(nullable: false),
                        ConcernId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProcessCId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductionProcessCs");
            DropTable("dbo.ProductionProcessBs");
            DropTable("dbo.ProductionProcessAs");
        }
    }
}
