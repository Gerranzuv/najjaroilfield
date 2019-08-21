namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeeprospectNewFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeProspects", "MaritalStatus", c => c.String(nullable: false));
            AddColumn("dbo.EmployeeProspects", "PhoneNumber", c => c.String(nullable: false));
            AddColumn("dbo.EmployeeProspects", "FixedNumber", c => c.String());
            AddColumn("dbo.EmployeeProspects", "militaryService", c => c.String(nullable: false));
            AddColumn("dbo.EmployeeProspects", "StartDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeProspects", "StartDate");
            DropColumn("dbo.EmployeeProspects", "militaryService");
            DropColumn("dbo.EmployeeProspects", "FixedNumber");
            DropColumn("dbo.EmployeeProspects", "PhoneNumber");
            DropColumn("dbo.EmployeeProspects", "MaritalStatus");
        }
    }
}
