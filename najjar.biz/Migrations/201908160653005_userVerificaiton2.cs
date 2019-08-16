namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userVerificaiton2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserVerificationLogs", "Code", c => c.String());
            AlterColumn("dbo.UserVerificationLogs", "Status", c => c.String());
            AlterColumn("dbo.UserVerificationLogs", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserVerificationLogs", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.UserVerificationLogs", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.UserVerificationLogs", "Code", c => c.String(nullable: false));
        }
    }
}
