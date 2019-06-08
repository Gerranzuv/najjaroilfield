namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2019 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "OrgUnit", c => c.String());
            AlterColumn("dbo.Employees", "WorkSchedule", c => c.String());
            AlterColumn("dbo.Employees", "PersonalArea", c => c.String());
            AlterColumn("dbo.Employees", "MESSAGES", c => c.String());
            AlterColumn("dbo.Employees", "CurrencyPaidIn", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "CurrencyPaidIn", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "MESSAGES", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "PersonalArea", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "WorkSchedule", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "OrgUnit", c => c.String(nullable: false));
        }
    }
}
