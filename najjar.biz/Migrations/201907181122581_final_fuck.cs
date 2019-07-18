namespace najjar.biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final_fuck : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Choices", "QuestionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "QuestionCategory_Id", c => c.Int());
            AlterColumn("dbo.TestXQuestions", "TestId", c => c.Int(nullable: false));
            AlterColumn("dbo.TestXQuestions", "QuestionId", c => c.Int(nullable: false));
            AlterColumn("dbo.QuestionXDurations", "RegistrationId", c => c.Int(nullable: false));
            AlterColumn("dbo.QuestionXDurations", "TestXQuestionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Registrations", "TestId", c => c.Int(nullable: false));
            AlterColumn("dbo.Registrations", "EmployeeId", c => c.Int(nullable: false));
            AlterColumn("dbo.TestXPapers", "RegistrationId", c => c.Int(nullable: false));
            AlterColumn("dbo.TestXPapers", "TestXQuestionId", c => c.Int(nullable: false));
            AlterColumn("dbo.TestXPapers", "ChoiceId", c => c.Int(nullable: false));
            AlterColumn("dbo.FileDetails", "SupportId", c => c.Int(nullable: false));
            AlterColumn("dbo.Supports", "employee_Id", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String());
            AlterColumn("dbo.AspNetUserClaims", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserLogins", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserRoles", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserRoles", "RoleId", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUserRoles", "RoleId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserRoles", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserLogins", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUserClaims", "User_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Supports", "employee_Id", c => c.Int());
            AlterColumn("dbo.FileDetails", "SupportId", c => c.Int(nullable: false));
            AlterColumn("dbo.TestXPapers", "ChoiceId", c => c.Int(nullable: false));
            AlterColumn("dbo.TestXPapers", "TestXQuestionId", c => c.Int(nullable: false));
            AlterColumn("dbo.TestXPapers", "RegistrationId", c => c.Int(nullable: false));
            AlterColumn("dbo.Registrations", "EmployeeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Registrations", "TestId", c => c.Int(nullable: false));
            AlterColumn("dbo.QuestionXDurations", "TestXQuestionId", c => c.Int(nullable: false));
            AlterColumn("dbo.QuestionXDurations", "RegistrationId", c => c.Int(nullable: false));
            AlterColumn("dbo.TestXQuestions", "QuestionId", c => c.Int(nullable: false));
            AlterColumn("dbo.TestXQuestions", "TestId", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "QuestionCategory_Id", c => c.Int());
            AlterColumn("dbo.Choices", "QuestionId", c => c.Int(nullable: false));
        }
    }
}
