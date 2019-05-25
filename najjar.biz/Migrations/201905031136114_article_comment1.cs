namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class article_comment1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobRequests",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        LastModificationDate = c.DateTime(nullable: false),
                        JobId = c.Int(nullable: false),
                        EmailAddress = c.String(nullable: false, maxLength: 250),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        LastModificationDate = c.DateTime(nullable: false),
                        AnnouncementDate = c.DateTime(nullable: false),
                        ClosingDate = c.DateTime(nullable: false),
                        Title = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        MilitaryService = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        Breifdescreption = c.String(nullable: false),
                        Detaileddescreption = c.String(nullable: false),
                        jobRequierment = c.String(nullable: false),
                        AverageSalary = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Jobs");
            DropTable("dbo.JobRequests");
        }
    }
}
