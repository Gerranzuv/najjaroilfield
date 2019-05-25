namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class article_comment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArticleComments", "Articleid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArticleComments", "Articleid");
        }
    }
}
