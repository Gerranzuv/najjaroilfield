namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resume4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WorkExperiences", "Position", c => c.String());
            AlterColumn("dbo.WorkExperiences", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkExperiences", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.WorkExperiences", "Position", c => c.String(nullable: false));
        }
    }
}
