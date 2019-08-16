namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userVerificationHelper : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserVerificationLogs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LastModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ConfirmationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ExpiryDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Code = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        IsEmailSent = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserVerificationLogs");
        }
    }
}
