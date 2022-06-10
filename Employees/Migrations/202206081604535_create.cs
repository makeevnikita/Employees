namespace Employees.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Name = c.String(),
                        Patronymic = c.String(),
                        Post_Id = c.Int(),
                        Subdivision_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .ForeignKey("dbo.Subdivisions", t => t.Subdivision_Id)
                .Index(t => t.Post_Id)
                .Index(t => t.Subdivision_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: false),
                        PostName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subdivisions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubdivisionName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Subdivision_Id", "dbo.Subdivisions");
            DropForeignKey("dbo.Employees", "Post_Id", "dbo.Posts");
            DropIndex("dbo.Employees", new[] { "Subdivision_Id" });
            DropIndex("dbo.Employees", new[] { "Post_Id" });
            DropTable("dbo.Subdivisions");
            DropTable("dbo.Posts");
            DropTable("dbo.Employees");
        }
    }
}
