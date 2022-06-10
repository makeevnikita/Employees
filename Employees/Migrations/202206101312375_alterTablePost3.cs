namespace Employees.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterTablePost3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Employees", "Subdivision_Id", "dbo.Subdivisions");
            DropIndex("dbo.Employees", new[] { "Post_Id" });
            DropIndex("dbo.Employees", new[] { "Subdivision_Id" });
            RenameColumn(table: "dbo.Employees", name: "Post_Id", newName: "PostId");
            RenameColumn(table: "dbo.Employees", name: "Subdivision_Id", newName: "SubdivisionId");
            AlterColumn("dbo.Employees", "PostId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "SubdivisionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "PostId");
            CreateIndex("dbo.Employees", "SubdivisionId");
            AddForeignKey("dbo.Employees", "PostId", "dbo.Posts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "SubdivisionId", "dbo.Subdivisions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.Employees", "PostId", "dbo.Posts");
            DropIndex("dbo.Employees", new[] { "SubdivisionId" });
            DropIndex("dbo.Employees", new[] { "PostId" });
            AlterColumn("dbo.Employees", "SubdivisionId", c => c.Int());
            AlterColumn("dbo.Employees", "PostId", c => c.Int());
            RenameColumn(table: "dbo.Employees", name: "SubdivisionId", newName: "Subdivision_Id");
            RenameColumn(table: "dbo.Employees", name: "PostId", newName: "Post_Id");
            CreateIndex("dbo.Employees", "Subdivision_Id");
            CreateIndex("dbo.Employees", "Post_Id");
            AddForeignKey("dbo.Employees", "Subdivision_Id", "dbo.Subdivisions", "Id");
            AddForeignKey("dbo.Employees", "Post_Id", "dbo.Posts", "Id");
        }
    }
}
