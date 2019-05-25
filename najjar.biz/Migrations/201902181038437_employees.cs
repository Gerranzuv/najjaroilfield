namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employees : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "EId", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "TotalSalary", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "DirectManager", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "FixedNumber", c => c.String());
            AlterColumn("dbo.Employees", "TypeOfEmployee", c => c.String());
            AlterColumn("dbo.Employees", "SalaryTrasfereMethod", c => c.String());
            AlterColumn("dbo.Employees", "SalaryTransfereDestination", c => c.String());
            AlterColumn("dbo.Employees", "EmployeeImage", c => c.String(nullable: false));
            DropColumn("dbo.Employees", "Code");
            DropColumn("dbo.Employees", "Joiningdate");
            DropColumn("dbo.Employees", "FullSalary");
            DropColumn("dbo.Employees", "Manager");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Manager", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "FullSalary", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "Joiningdate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "EmployeeImage", c => c.String());
            AlterColumn("dbo.Employees", "SalaryTransfereDestination", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "SalaryTrasfereMethod", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "TypeOfEmployee", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "FixedNumber", c => c.String(nullable: false));
            DropColumn("dbo.Employees", "DirectManager");
            DropColumn("dbo.Employees", "TotalSalary");
            DropColumn("dbo.Employees", "StartDate");
            DropColumn("dbo.Employees", "EId");
        }
    }
}
