namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedExamSystemMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registrations", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Registrations", "EmployeeId");
            AddForeignKey("dbo.Registrations", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registrations", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Registrations", new[] { "EmployeeId" });
            DropColumn("dbo.Registrations", "EmployeeId");
        }
    }
}
