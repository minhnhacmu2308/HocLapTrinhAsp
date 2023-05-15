namespace HocLapTrinhAspNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        Image = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsFree = c.Boolean(nullable: false),
                        CourseTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.CourseTypes", t => t.CourseTypeId)
                .Index(t => t.CourseTypeId);
            
            CreateTable(
                "dbo.CourseTypes",
                c => new
                    {
                        CourseTypeId = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.CourseTypeId);
            
            CreateTable(
                "dbo.CourseVideos",
                c => new
                    {
                        CourseVideoId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        VideoName = c.String(),
                        VideoUrl = c.String(),
                    })
                .PrimaryKey(t => t.CourseVideoId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Image = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.NewsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseVideos", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "CourseTypeId", "dbo.CourseTypes");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Orders", new[] { "CourseId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.CourseVideos", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "CourseTypeId" });
            DropTable("dbo.News");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.CourseVideos");
            DropTable("dbo.CourseTypes");
            DropTable("dbo.Courses");
        }
    }
}
