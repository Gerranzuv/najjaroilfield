namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class obada : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Location", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "Grade", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "position", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "position");
            DropColumn("dbo.Employees", "Grade");
            DropColumn("dbo.Employees", "Location");
        }
    }
}
