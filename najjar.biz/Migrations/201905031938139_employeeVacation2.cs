namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeeVacation2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeesVacations", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeesVacations", "Status");
        }
    }
}
