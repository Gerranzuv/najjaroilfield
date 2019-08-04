namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test_question_limit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tests", "QuestionLimit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tests", "QuestionLimit");
        }
    }
}
