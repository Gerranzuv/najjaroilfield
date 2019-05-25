namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class account1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "TrasportAllowance", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "MonthlySalary", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "OrgUnit", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "WorkSchedule", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "PersonalArea", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "CostCenter", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "TelephoneFaxExpenses", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "Others", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "RelocAllowNoTax", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "MiscellaneousDeductions", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "DSPP", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "NetPay", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "TotalEarnings", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "TotalDeductions", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "MESSAGES", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "AccountNumber", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "CurrencyPaidIn", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "ExhangeRate", c => c.Double(nullable: false));
            DropColumn("dbo.Employees", "Trasportation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Trasportation", c => c.Double(nullable: false));
            DropColumn("dbo.Employees", "ExhangeRate");
            DropColumn("dbo.Employees", "CurrencyPaidIn");
            DropColumn("dbo.Employees", "AccountNumber");
            DropColumn("dbo.Employees", "MESSAGES");
            DropColumn("dbo.Employees", "TotalDeductions");
            DropColumn("dbo.Employees", "TotalEarnings");
            DropColumn("dbo.Employees", "NetPay");
            DropColumn("dbo.Employees", "DSPP");
            DropColumn("dbo.Employees", "MiscellaneousDeductions");
            DropColumn("dbo.Employees", "RelocAllowNoTax");
            DropColumn("dbo.Employees", "Others");
            DropColumn("dbo.Employees", "TelephoneFaxExpenses");
            DropColumn("dbo.Employees", "CostCenter");
            DropColumn("dbo.Employees", "PersonalArea");
            DropColumn("dbo.Employees", "WorkSchedule");
            DropColumn("dbo.Employees", "OrgUnit");
            DropColumn("dbo.Employees", "MonthlySalary");
            DropColumn("dbo.Employees", "TrasportAllowance");
        }
    }
}
