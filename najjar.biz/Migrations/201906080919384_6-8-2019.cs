namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _682019 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Choices", "Label", c => c.String());
            AlterColumn("dbo.Questions", "QuestionText", c => c.String());
            DropColumn("dbo.Employees", "Trasportation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Trasportation", c => c.Double(nullable: false));
            AlterColumn("dbo.Questions", "QuestionText", c => c.String(nullable: false));
            AlterColumn("dbo.Choices", "Label", c => c.String(nullable: false));
        }
    }
}
