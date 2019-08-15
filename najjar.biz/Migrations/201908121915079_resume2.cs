namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resume2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkExperiences", "WorkExperience_id", c => c.Int());
            AlterColumn("dbo.EmployeeProspects", "id", c => c.Int(nullable: false));
            CreateIndex("dbo.EmployeeProspects", "EmployeeProspectId");
            CreateIndex("dbo.WorkExperiences", "WorkExperience_id");
            AddForeignKey("dbo.EmployeeProspects", "EmployeeProspectId", "dbo.EmployeeProspects", "id");
            AddForeignKey("dbo.WorkExperiences", "WorkExperience_id", "dbo.WorkExperiences", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkExperiences", "WorkExperience_id", "dbo.WorkExperiences");
            DropForeignKey("dbo.EmployeeProspects", "EmployeeProspectId", "dbo.EmployeeProspects");
            DropIndex("dbo.WorkExperiences", new[] { "WorkExperience_id" });
            DropIndex("dbo.EmployeeProspects", new[] { "EmployeeProspectId" });
            AlterColumn("dbo.EmployeeProspects", "id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.WorkExperiences", "WorkExperience_id");
        }
    }
}
