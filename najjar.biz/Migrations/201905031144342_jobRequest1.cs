namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobRequest1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "Category", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "Category", c => c.String(nullable: false));
        }
    }
}
