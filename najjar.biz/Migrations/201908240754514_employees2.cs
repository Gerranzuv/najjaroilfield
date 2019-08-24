namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employees2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Department", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Department", c => c.String(nullable: false));
        }
    }
}
