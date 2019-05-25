namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArticleComment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticleComments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Comment = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ArticleComments");
        }
    }
}
