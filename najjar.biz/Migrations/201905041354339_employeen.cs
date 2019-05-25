namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Country", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "EmployeeCode", c => c.String());
            AlterColumn("dbo.Employees", "Location", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Location", c => c.String(nullable: false));
            DropColumn("dbo.Employees", "EmployeeCode");
            DropColumn("dbo.Employees", "Country");
        }
    }
}
