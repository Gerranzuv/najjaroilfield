namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeeVsEmployeeProspect : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeProspects", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "IsProspect", c => c.Boolean(nullable: false));
            CreateIndex("dbo.EmployeeProspects", "EmployeeId");
            AddForeignKey("dbo.EmployeeProspects", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeProspects", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeProspects", new[] { "EmployeeId" });
            DropColumn("dbo.Employees", "IsProspect");
            DropColumn("dbo.EmployeeProspects", "EmployeeId");
        }
    }
}
