namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fuck : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "EmployeeImage", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "EmployeeImage", c => c.String());
        }
    }
}
