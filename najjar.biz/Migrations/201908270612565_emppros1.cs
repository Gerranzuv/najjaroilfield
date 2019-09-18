namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emppros1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeProspects", "Creator", c => c.String());
            AddColumn("dbo.EmployeeProspects", "Modifier", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeProspects", "Modifier");
            DropColumn("dbo.EmployeeProspects", "Creator");
        }
    }
}
