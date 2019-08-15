namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resume3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeProspects", "EmployeeProspectId", "dbo.EmployeeProspects");
            DropForeignKey("dbo.WorkExperiences", "WorkExperience_id", "dbo.WorkExperiences");
            DropIndex("dbo.EmployeeProspects", new[] { "EmployeeProspectId" });
            DropIndex("dbo.WorkExperiences", new[] { "WorkExperience_id" });
            AddColumn("dbo.EmployeeProspects", "Name", c => c.String(nullable: false));
            AddColumn("dbo.EmployeeProspects", "Address", c => c.String(nullable: false));
            AddColumn("dbo.EmployeeProspects", "AddressInArabic", c => c.String(nullable: false));
            AddColumn("dbo.EmployeeProspects", "Email", c => c.String(nullable: false));
            AddColumn("dbo.EmployeeProspects", "EmployeeImage", c => c.String());
            AddColumn("dbo.EmployeeProspects", "Nationality", c => c.String(nullable: false));
            AddColumn("dbo.EmployeeProspects", "BirthDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.EmployeeProspects", "Sex", c => c.String(nullable: false));
            AddColumn("dbo.EmployeeProspects", "BirthPlace", c => c.String(nullable: false));
            AddColumn("dbo.WorkExperiences", "From", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.WorkExperiences", "To", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.WorkExperiences", "Position", c => c.String(nullable: false));
            AddColumn("dbo.WorkExperiences", "Description", c => c.String(nullable: false));
            AddColumn("dbo.WorkExperiences", "EmployeeProspectId", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeeProspects", "id", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.WorkExperiences", "EmployeeProspectId");
            AddForeignKey("dbo.WorkExperiences", "EmployeeProspectId", "dbo.EmployeeProspects", "id", cascadeDelete: true);
            DropColumn("dbo.EmployeeProspects", "From");
            DropColumn("dbo.EmployeeProspects", "To");
            DropColumn("dbo.EmployeeProspects", "Position");
            DropColumn("dbo.EmployeeProspects", "Description");
            DropColumn("dbo.EmployeeProspects", "EmployeeProspectId");
            DropColumn("dbo.WorkExperiences", "Name");
            DropColumn("dbo.WorkExperiences", "Address");
            DropColumn("dbo.WorkExperiences", "AddressInArabic");
            DropColumn("dbo.WorkExperiences", "Email");
            DropColumn("dbo.WorkExperiences", "EmployeeImage");
            DropColumn("dbo.WorkExperiences", "Nationality");
            DropColumn("dbo.WorkExperiences", "BirthDate");
            DropColumn("dbo.WorkExperiences", "Sex");
            DropColumn("dbo.WorkExperiences", "BirthPlace");
            DropColumn("dbo.WorkExperiences", "WorkExperience_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkExperiences", "WorkExperience_id", c => c.Int());
            AddColumn("dbo.WorkExperiences", "BirthPlace", c => c.String(nullable: false));
            AddColumn("dbo.WorkExperiences", "Sex", c => c.String(nullable: false));
            AddColumn("dbo.WorkExperiences", "BirthDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.WorkExperiences", "Nationality", c => c.String(nullable: false));
            AddColumn("dbo.WorkExperiences", "EmployeeImage", c => c.String());
            AddColumn("dbo.WorkExperiences", "Email", c => c.String(nullable: false));
            AddColumn("dbo.WorkExperiences", "AddressInArabic", c => c.String(nullable: false));
            AddColumn("dbo.WorkExperiences", "Address", c => c.String(nullable: false));
            AddColumn("dbo.WorkExperiences", "Name", c => c.String(nullable: false));
            AddColumn("dbo.EmployeeProspects", "EmployeeProspectId", c => c.Int(nullable: false));
            AddColumn("dbo.EmployeeProspects", "Description", c => c.String(nullable: false));
            AddColumn("dbo.EmployeeProspects", "Position", c => c.String(nullable: false));
            AddColumn("dbo.EmployeeProspects", "To", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.EmployeeProspects", "From", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropForeignKey("dbo.WorkExperiences", "EmployeeProspectId", "dbo.EmployeeProspects");
            DropIndex("dbo.WorkExperiences", new[] { "EmployeeProspectId" });
            AlterColumn("dbo.EmployeeProspects", "id", c => c.Int(nullable: false));
            DropColumn("dbo.WorkExperiences", "EmployeeProspectId");
            DropColumn("dbo.WorkExperiences", "Description");
            DropColumn("dbo.WorkExperiences", "Position");
            DropColumn("dbo.WorkExperiences", "To");
            DropColumn("dbo.WorkExperiences", "From");
            DropColumn("dbo.EmployeeProspects", "BirthPlace");
            DropColumn("dbo.EmployeeProspects", "Sex");
            DropColumn("dbo.EmployeeProspects", "BirthDate");
            DropColumn("dbo.EmployeeProspects", "Nationality");
            DropColumn("dbo.EmployeeProspects", "EmployeeImage");
            DropColumn("dbo.EmployeeProspects", "Email");
            DropColumn("dbo.EmployeeProspects", "AddressInArabic");
            DropColumn("dbo.EmployeeProspects", "Address");
            DropColumn("dbo.EmployeeProspects", "Name");
            CreateIndex("dbo.WorkExperiences", "WorkExperience_id");
            CreateIndex("dbo.EmployeeProspects", "EmployeeProspectId");
            AddForeignKey("dbo.WorkExperiences", "WorkExperience_id", "dbo.WorkExperiences", "id");
            AddForeignKey("dbo.EmployeeProspects", "EmployeeProspectId", "dbo.EmployeeProspects", "id");
        }
    }
}
