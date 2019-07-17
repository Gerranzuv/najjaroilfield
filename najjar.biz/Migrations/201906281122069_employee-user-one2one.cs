namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeeuserone2one : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "EmployeeId", c => c.Int());
            DropColumn("dbo.AspNetUsers", "Employee_Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Employee_Code", c => c.String());
            DropColumn("dbo.AspNetUsers", "EmployeeId");
        }
    }
}
