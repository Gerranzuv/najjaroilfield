namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRegistration_Employee_Models : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registrations", "Token", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Registrations", "Token");
        }
    }
}
