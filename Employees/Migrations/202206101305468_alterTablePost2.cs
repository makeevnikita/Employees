namespace Employees.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterTablePost2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Employees", "SubdivisionId", "dbo.Subdivisions");
            DropIndex("dbo.Employees", new[] { "SubdivisionId" });
            DropIndex("dbo.Employees", new[] { "PostId" });
            RenameColumn(table: "dbo.Employees", name: "PostId", newName: "Post_Id");
            RenameColumn(table: "dbo.Employees", name: "SubdivisionId", newName: "Subdivision_Id");
            AlterColumn("dbo.Employees", "Subdivision_Id", c => c.Int());
            AlterColumn("dbo.Employees", "Post_Id", c => c.Int());
            CreateIndex("dbo.Employees", "Post_Id");
            CreateIndex("dbo.Employees", "Subdivision_Id");
            AddForeignKey("dbo.Employees", "Post_Id", "dbo.Posts", "Id");
            AddForeignKey("dbo.Employees", "Subdivision_Id", "dbo.Subdivisions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Subdivision_Id", "dbo.Subdivisions");
            DropForeignKey("dbo.Employees", "Post_Id", "dbo.Posts");
            DropIndex("dbo.Employees", new[] { "Subdivision_Id" });
            DropIndex("dbo.Employees", new[] { "Post_Id" });
            AlterColumn("dbo.Employees", "Post_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "Subdivision_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Employees", name: "Subdivision_Id", newName: "SubdivisionId");
            RenameColumn(table: "dbo.Employees", name: "Post_Id", newName: "PostId");
            CreateIndex("dbo.Employees", "PostId");
            CreateIndex("dbo.Employees", "SubdivisionId");
            AddForeignKey("dbo.Employees", "SubdivisionId", "dbo.Subdivisions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
        }
    }
}
