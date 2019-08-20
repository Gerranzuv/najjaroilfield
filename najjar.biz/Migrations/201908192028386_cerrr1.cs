namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cerrr1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Certifications", "EmployeeProspectId", c => c.Int(nullable: false));
            AddColumn("dbo.Certifications", "WorkExperience_id", c => c.Int());
            CreateIndex("dbo.Certifications", "WorkExperience_id");
            CreateIndex("dbo.Certifications", "EmployeeProspectId");
            AddForeignKey("dbo.Certifications", "WorkExperience_id", "dbo.WorkExperiences", "id");
            AddForeignKey("dbo.Certifications", "EmployeeProspectId", "dbo.EmployeeProspects", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Certifications", "EmployeeProspectId", "dbo.EmployeeProspects");
            DropForeignKey("dbo.Certifications", "WorkExperience_id", "dbo.WorkExperiences");
            DropIndex("dbo.Certifications", new[] { "EmployeeProspectId" });
            DropIndex("dbo.Certifications", new[] { "WorkExperience_id" });
            DropColumn("dbo.Certifications", "WorkExperience_id");
            DropColumn("dbo.Certifications", "EmployeeProspectId");
        }
    }
}
