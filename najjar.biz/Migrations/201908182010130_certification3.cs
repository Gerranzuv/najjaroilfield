namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class certification3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Certifications", "Creator_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Certifications", "Modifier_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Certifications", "Creator_Id");
            CreateIndex("dbo.Certifications", "Modifier_Id");
            AddForeignKey("dbo.Certifications", "Creator_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Certifications", "Modifier_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Certifications", "Modifier_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Certifications", "Creator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Certifications", new[] { "Modifier_Id" });
            DropIndex("dbo.Certifications", new[] { "Creator_Id" });
            DropColumn("dbo.Certifications", "Modifier_Id");
            DropColumn("dbo.Certifications", "Creator_Id");
        }
    }
}
