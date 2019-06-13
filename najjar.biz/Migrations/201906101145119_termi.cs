namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class termi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "TerminationMode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "TerminationMode");
        }
    }
}
