namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workExperience6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Certifications", "Creator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Certifications", "Modifier_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.WorkExperiences", "Creator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.WorkExperiences", "Modifier_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Certifications", new[] { "Creator_Id" });
            DropIndex("dbo.Certifications", new[] { "Modifier_Id" });
            DropIndex("dbo.WorkExperiences", new[] { "Creator_Id" });
            DropIndex("dbo.WorkExperiences", new[] { "Modifier_Id" });
            AddColumn("dbo.Certifications", "Creator", c => c.String());
            AddColumn("dbo.Certifications", "Modifier", c => c.String());
            AddColumn("dbo.WorkExperiences", "Creator", c => c.String());
            AddColumn("dbo.WorkExperiences", "Modifier", c => c.String());
            DropColumn("dbo.Certifications", "Creator_Id");
            DropColumn("dbo.Certifications", "Modifier_Id");
            DropColumn("dbo.WorkExperiences", "Creator_Id");
            DropColumn("dbo.WorkExperiences", "Modifier_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkExperiences", "Modifier_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.WorkExperiences", "Creator_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Certifications", "Modifier_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Certifications", "Creator_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.WorkExperiences", "Modifier");
            DropColumn("dbo.WorkExperiences", "Creator");
            DropColumn("dbo.Certifications", "Modifier");
            DropColumn("dbo.Certifications", "Creator");
            CreateIndex("dbo.WorkExperiences", "Modifier_Id");
            CreateIndex("dbo.WorkExperiences", "Creator_Id");
            CreateIndex("dbo.Certifications", "Modifier_Id");
            CreateIndex("dbo.Certifications", "Creator_Id");
            AddForeignKey("dbo.WorkExperiences", "Modifier_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.WorkExperiences", "Creator_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Certifications", "Modifier_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Certifications", "Creator_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
