namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kinan2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobRequests", "jobName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobRequests", "jobName");
        }
    }
}
