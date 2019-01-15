namespace PermessInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyAddress = c.String(),
                        ContactPerson = c.String(),
                        MobileNo = c.String(),
                        ConcerinId = c.Int(nullable: false),
                        Creator = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ConcernId = c.Int(nullable: false),
                        Creator = c.Int(nullable: false),
                        CreationDate = c.Int(nullable: false),
                        Description = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductSettings",
                c => new
                    {
                        ProductSettId = c.Int(nullable: false, identity: true),
                        Article = c.String(),
                        Construction = c.String(),
                        Width = c.String(),
                        Softness = c.String(),
                        Color = c.String(),
                        Source = c.String(),
                        Category = c.String(),
                        ConcernId = c.Int(nullable: false),
                        Creator = c.Int(nullable: false),
                        CreationDate = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ProductSettId);
            
            CreateTable(
                "dbo.SystemUsers",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        UserRole = c.Int(nullable: false),
                        Password = c.String(),
                        IsDisabled = c.Int(nullable: false),
                        LoginDate = c.DateTime(nullable: false),
                        EmailAddress = c.String(),
                        LoginFailedCount = c.Int(nullable: false),
                        Language = c.String(),
                        ActivationDate = c.DateTime(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        HashSalt = c.String(),
                        CreatorId = c.Int(nullable: false),
                        ConcernID = c.Int(nullable: false),
                        IsDelete = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        UserRoleName = c.String(),
                        ConcernId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Creator = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserRoleId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserRoles");
            DropTable("dbo.SystemUsers");
            DropTable("dbo.ProductSettings");
            DropTable("dbo.Products");
            DropTable("dbo.Companies");
        }
    }
}
