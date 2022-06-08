namespace Employees.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterTableEmployees : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employees", name: "Supervisor_Id", newName: "Post_Id");
            RenameIndex(table: "dbo.Employees", name: "IX_Supervisor_Id", newName: "IX_Post_Id");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronymic = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            RenameIndex(table: "dbo.Employees", name: "IX_Post_Id", newName: "IX_Supervisor_Id");
            RenameColumn(table: "dbo.Employees", name: "Post_Id", newName: "Supervisor_Id");
        }
    }
}
