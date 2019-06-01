namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExamSystemMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Choices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        Label = c.String(),
                        points = c.Double(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        points = c.Double(nullable: false),
                        QuestionType = c.String(),
                        QuestionText = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        QuestionCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionCategories", t => t.QuestionCategory_Id)
                .Index(t => t.QuestionCategory_Id);
            
            CreateTable(
                "dbo.QuestionCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestXQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        QuestionNumber = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.TestId, cascadeDelete: true)
                .Index(t => t.TestId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.QuestionXDurations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegistrationId = c.Int(nullable: false),
                        TestXQuestionId = c.Int(nullable: false),
                        RequestTime = c.DateTime(nullable: false),
                        LeaveTime = c.DateTime(nullable: false),
                        AnsweredTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Registrations", t => t.RegistrationId, cascadeDelete: true)
                .ForeignKey("dbo.TestXQuestions", t => t.TestXQuestionId, cascadeDelete: true)
                .Index(t => t.RegistrationId)
                .Index(t => t.TestXQuestionId);
            
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegistrationDate = c.DateTime(nullable: false),
                        ExpiresDate = c.DateTime(nullable: false),
                        TestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.TestId)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        DurationInMinutes = c.Int(nullable: false),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestXPapers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegistrationId = c.Int(nullable: false),
                        TestXQuestionId = c.Int(nullable: false),
                        ChoiceId = c.Int(nullable: false),
                        Answer = c.String(),
                        MarkScored = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Choices", t => t.ChoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Registrations", t => t.RegistrationId, cascadeDelete: true)
                .ForeignKey("dbo.TestXQuestions", t => t.TestXQuestionId)
                .Index(t => t.RegistrationId)
                .Index(t => t.TestXQuestionId)
                .Index(t => t.ChoiceId);
            
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionXDurations", "TestXQuestionId", "dbo.TestXQuestions");
            DropForeignKey("dbo.TestXPapers", "TestXQuestionId", "dbo.TestXQuestions");
            DropForeignKey("dbo.TestXPapers", "RegistrationId", "dbo.Registrations");
            DropForeignKey("dbo.TestXPapers", "ChoiceId", "dbo.Choices");
            DropForeignKey("dbo.TestXQuestions", "TestId", "dbo.Tests");
            DropForeignKey("dbo.Registrations", "TestId", "dbo.Tests");
            DropForeignKey("dbo.QuestionXDurations", "RegistrationId", "dbo.Registrations");
            DropForeignKey("dbo.TestXQuestions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "QuestionCategory_Id", "dbo.QuestionCategories");
            DropForeignKey("dbo.Choices", "QuestionId", "dbo.Questions");
            DropIndex("dbo.TestXPapers", new[] { "ChoiceId" });
            DropIndex("dbo.TestXPapers", new[] { "TestXQuestionId" });
            DropIndex("dbo.TestXPapers", new[] { "RegistrationId" });
            DropIndex("dbo.Registrations", new[] { "TestId" });
            DropIndex("dbo.QuestionXDurations", new[] { "TestXQuestionId" });
            DropIndex("dbo.QuestionXDurations", new[] { "RegistrationId" });
            DropIndex("dbo.TestXQuestions", new[] { "QuestionId" });
            DropIndex("dbo.TestXQuestions", new[] { "TestId" });
            DropIndex("dbo.Questions", new[] { "QuestionCategory_Id" });
            DropIndex("dbo.Choices", new[] { "QuestionId" });
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String());
            DropTable("dbo.TestXPapers");
            DropTable("dbo.Tests");
            DropTable("dbo.Registrations");
            DropTable("dbo.QuestionXDurations");
            DropTable("dbo.TestXQuestions");
            DropTable("dbo.QuestionCategories");
            DropTable("dbo.Questions");
            DropTable("dbo.Choices");
        }
    }
}
