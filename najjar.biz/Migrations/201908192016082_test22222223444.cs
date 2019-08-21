namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test22222223444 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Certifications", "EmployeeProspectId");
            AddForeignKey("dbo.Certifications", "EmployeeProspectId", "dbo.EmployeeProspects", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Certifications", "EmployeeProspectId", "dbo.EmployeeProspects");
            DropIndex("dbo.Certifications", new[] { "EmployeeProspectId" });
        }
    }
}
