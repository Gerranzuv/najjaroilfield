namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userVerificationHelper1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserVerificationLogs", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserVerificationLogs", "UserId", c => c.Int(nullable: false));
        }
    }
}
