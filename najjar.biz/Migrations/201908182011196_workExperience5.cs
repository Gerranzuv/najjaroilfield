namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workExperience5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkExperiences", "Creator_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.WorkExperiences", "Modifier_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.WorkExperiences", "Creator_Id");
            CreateIndex("dbo.WorkExperiences", "Modifier_Id");
            AddForeignKey("dbo.WorkExperiences", "Creator_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.WorkExperiences", "Modifier_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkExperiences", "Modifier_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.WorkExperiences", "Creator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.WorkExperiences", new[] { "Modifier_Id" });
            DropIndex("dbo.WorkExperiences", new[] { "Creator_Id" });
            DropColumn("dbo.WorkExperiences", "Modifier_Id");
            DropColumn("dbo.WorkExperiences", "Creator_Id");
        }
    }
}
