namespace najjar.biz.Migrations
{
    using najjar.biz.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<najjar.biz.Context.ApplicationDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(najjar.biz.Context.ApplicationDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // Clear Database
        //    context.Database.ExecuteSqlCommand("DELETE FROM dbo.QuestionCategories");
        //    context.Database.ExecuteSqlCommand("DELETE FROM dbo.Registrations");
        //    context.Database.ExecuteSqlCommand("DELETE FROM dbo.TestXPapers");
        //    context.Database.ExecuteSqlCommand("DELETE FROM dbo.Tests");
        //    context.Database.ExecuteSqlCommand("DELETE FROM dbo.Questions");
        //    context.Database.ExecuteSqlCommand("DELETE FROM dbo.TestXQuestions");
        //    context.Database.ExecuteSqlCommand("DELETE FROM dbo.Choices");

        //    // Add Question Categories...
        //    context.QuestionCategories.AddOrUpdate(cat => cat.Id,
        //        new QuestionCategory() { Id=1, Category = "single_choice" },
        //        new QuestionCategory { Id=2, Category = "multi_choice" });

        //    // Add Tests...

        //    context.Tests.AddOrUpdate(Test => Test.Id,
        //        new Test() {
        //            Id=1,
        //            Name ="IT Test",
        //            Description = "This Test will evaluate the employee Computer Skills...",
        //            isActive =true,
        //            DurationInMinutes =30
        //        },
        //        new Test()
        //        {
        //            Id=2,
        //            Name = "HR Test",
        //            Description = "This Test will evaluate the HR Department Skills...",
        //            isActive = true,
        //            DurationInMinutes = 60
        //        },
        //        new Test()
        //        {
        //            Id=3,
        //            Name = "Oil Field Test",
        //            Description = "This Test will evaluate Oil Engineers Skills to deal with field Tasks...",
        //            isActive = true,
        //            DurationInMinutes = 90
        //        });

        //    // Add sample Questions...
        //    context.Questions.AddOrUpdate(
                
        //        // 1
        //        new Question() {
        //            Id=1,
        //            QuestionText = "Select The Correct Answer",
        //            points = 4,
        //            IsActive = true,
        //            CategoryId = 1,
        //            QuestionType = "single_choice",
        //        },
        //        // 2
        //        new Question()
        //        {
        //            Id = 2,
        //            QuestionText = "Select All Correct Answers",
        //            points = 4,
        //            IsActive = true,
        //            CategoryId = 2,
        //            QuestionType = "multi_choice"
        //        },
        //        // 3
        //        new Question()
        //        {
        //            Id = 3,
        //            QuestionText = "Select The Correct Answer",
        //            points = 4,
        //            IsActive = true,
        //            CategoryId = 1,
        //            QuestionType = "single_choice"
        //        },
        //        // 4
        //        new Question()
        //        {
        //            Id = 4,
        //            QuestionText = "Select The Correct Answer",
        //            points = 4,
        //            IsActive = true,
        //            CategoryId = 1,
        //            QuestionType = "single_choice"
        //        },
        //        // 5
        //        new Question()
        //        {
        //            Id = 5,
        //            QuestionText = "Select The Correct Answer",
        //            points = 4,
        //            IsActive = true,
        //            CategoryId = 1,
        //            QuestionType = "single_choice"
        //        },
        //        // 6
        //        new Question()
        //        {
        //            Id = 6,
        //            QuestionText = "Select The Correct Answer",
        //            points = 4,
        //            IsActive = true,
        //            CategoryId = 1,
        //            QuestionType = "single_choice"
        //        },
        //        // 7
        //        new Question()
        //        {
        //            Id = 7,
        //            QuestionText = "Select All Correct Answers",
        //            points = 4,
        //            IsActive = true,
        //            CategoryId = 2,
        //            QuestionType = "multi_choice"
        //        },
        //        // 8
        //        new Question()
        //        {
        //            Id = 8,
        //            QuestionText = "Select The Correct Answer",
        //            points = 4,
        //            IsActive = true,
        //            CategoryId = 1,
        //            QuestionType = "single_choice"
        //        },
        //        // 9
        //        new Question()
        //        {
        //            Id = 9,
        //            QuestionText = "Select The Correct Answer",
        //            points = 4,
        //            IsActive = true,
        //            CategoryId = 1,
        //            QuestionType = "single_choice"
        //        },
        //        // 10
        //        new Question()
        //        {
        //            Id = 10,
        //            QuestionText = "Select The Correct Answer",
        //            points = 4,
        //            IsActive = true,
        //            CategoryId = 1,
        //            QuestionType = "single_choice"
        //        },
        //        // 11
        //        new Question()
        //        {
        //            Id = 11,
        //            QuestionText = "Select All Correct Answers",
        //            points = 4,
        //            IsActive = true,
        //            CategoryId = 2,
        //            QuestionType = "multi_choice"
        //        },
        //        // 12
        //        new Question()
        //        {
        //            Id = 12,
        //            QuestionText = "Select The Correct Answer",
        //            points = 4,
        //            IsActive = true,
        //            CategoryId = 1,
        //            QuestionType = "single_choice"
        //        },
        //        // 13
        //        new Question()
        //        {
        //            Id = 13,
        //            QuestionText = "Select All Correct Answers",
        //            points = 4,
        //            IsActive = true,
        //            CategoryId = 2,
        //            QuestionType = "multi_choice"
        //        },
        //        // 14
        //        new Question()
        //        {
        //            Id = 14,
        //            QuestionText = "Select All Correct Answers",
        //            points = 4,
        //            IsActive = true,
        //            CategoryId = 2,
        //            QuestionType = "multi_choice"
        //        },
        //        // 15
        //        new Question()
        //        {
        //            Id = 15,
        //            QuestionText = "Select the Correct Answer",
        //            points = 4,
        //            IsActive = true,
        //            CategoryId = 1,
        //            QuestionType = "single_choice"
        //        },
        //        // 16
        //        new Question()
        //        {
        //            Id = 16,
        //            QuestionText = "Select All Correct Answers",
        //            points = 4,
        //            IsActive = true,
        //            CategoryId = 2,
        //            QuestionType = "multi_choice"
        //        },
        //        // 17
        //        new Question()
        //        {
        //            Id = 17,
        //            QuestionText = "Select the The Correct Answer",
        //            points = 4,
        //            IsActive = true,
        //            CategoryId = 1,
        //            QuestionType = "single_choice"
        //        },
        //        // 18
        //        new Question()
        //        {
        //            Id = 18,
        //            QuestionText = "Select All Correct Answers",
        //            points = 4,
        //            IsActive = true,
        //            CategoryId = 2,
        //            QuestionType = "multi_choice"
        //        });

        //    context.TestXQuestions.AddOrUpdate(TestXQuestion => TestXQuestion.Id,
        //        new TestXQuestion()
        //        {
        //            Id = 1,
        //            TestId = 1,
        //            QuestionId = 1,
        //            QuestionNumber = 1,
        //            IsActive = true
        //        },
        //        new TestXQuestion()
        //        {
        //            Id = 2,
        //            TestId = 1,
        //            QuestionId = 2,
        //            QuestionNumber = 2,
        //            IsActive = true
        //        },
        //        new TestXQuestion()
        //        {
        //            Id = 3,
        //            TestId = 1,
        //            QuestionId = 3,
        //            QuestionNumber = 3,
        //            IsActive = true
        //        },
        //        new TestXQuestion()
        //        {
        //            Id = 4,
        //            TestId = 1,
        //            QuestionId = 4,
        //            QuestionNumber = 4,
        //            IsActive = true
        //        },
        //        new TestXQuestion()
        //        {
        //            Id = 5,
        //            TestId = 1,
        //            QuestionId = 5,
        //            QuestionNumber = 5,
        //            IsActive = true
        //        },
        //        new TestXQuestion()
        //        {
        //            Id = 6,
        //            TestId = 1,
        //            QuestionId = 6,
        //            QuestionNumber = 6,
        //            IsActive = true
        //        },
        //        new TestXQuestion()
        //        {
        //            Id = 7,
        //            TestId = 2,
        //            QuestionId = 7,
        //            QuestionNumber = 1,
        //            IsActive = true
        //        },
        //        new TestXQuestion()
        //        {
        //            Id = 8,
        //            TestId = 2,
        //            QuestionId = 8,
        //            QuestionNumber = 2,
        //            IsActive = true
        //        },
        //        new TestXQuestion()
        //        {
        //            Id = 9,
        //            TestId = 2,
        //            QuestionId = 9,
        //            QuestionNumber = 3,
        //            IsActive = true
        //        },
        //        new TestXQuestion()
        //        {
        //            Id = 10,
        //            TestId = 2,
        //            QuestionId = 10,
        //            QuestionNumber = 4,
        //            IsActive = true
        //        },
        //        new TestXQuestion()
        //        {
        //            Id = 11,
        //            TestId = 2,
        //            QuestionId = 11,
        //            QuestionNumber = 5,
        //            IsActive = true
        //        },
        //        new TestXQuestion()
        //        {
        //            Id = 12,
        //            TestId = 2,
        //            QuestionId = 12,
        //            QuestionNumber = 6,
        //            IsActive = true
        //        });

        //    context.Choices.AddOrUpdate(Choice => Choice.Id,
        //        new Choice()
        //        {
        //            Id = 1,
        //            QuestionId = 1,
        //            Label = "This Choice Number 1 is for Question 1",
        //            IsActive = true,
        //            points = 4
        //        },
        //        new Choice()
        //        {
        //            Id = 2,
        //            QuestionId = 1,
        //            Label = "This Choice Number 2 is for Question 1",
        //            IsActive = true,
        //            points = 0
        //        },
        //        new Choice()
        //        {
        //            Id = 3,
        //            QuestionId = 2,
        //            Label = "This Choice Number 1 is for Question 2",
        //            IsActive = true,
        //            points = 1.5
        //        },
        //        new Choice()
        //        {
        //            Id = 4,
        //            QuestionId = 2,
        //            Label = "This Choice Number 2 is for Question 2",
        //            IsActive = true,
        //            points = 0
        //        },
        //        new Choice()
        //        {
        //            Id = 5,
        //            QuestionId = 2,
        //            Label = "This Choice Number 3 is for Question 2",
        //            IsActive = true,
        //            points = 2.5
        //        },
        //        new Choice()
        //        {
        //            Id = 6,
        //            QuestionId = 3,
        //            Label = "This Choice Number 1 is for Question 3",
        //            IsActive = true,
        //            points = 0
        //        },
        //        new Choice()
        //        {
        //            Id = 7,
        //            QuestionId = 3,
        //            Label = "This Choice Number 2 is for Question 3",
        //            IsActive = true,
        //            points = 4
        //        },
        //        new Choice()
        //        {
        //            Id = 8,
        //            QuestionId = 4,
        //            Label = "This Choice Number 1 is for Question 4",
        //            IsActive = true,
        //            points = 0
        //        },
        //        new Choice()
        //        {
        //            Id = 9,
        //            QuestionId = 4,
        //            Label = "This Choice Number 2 is for Question 4",
        //            IsActive = true,
        //            points = 4
        //        },
        //        new Choice()
        //        {
        //            Id = 10,
        //            QuestionId = 5,
        //            Label = "This Choice Number 1 is for Question 5",
        //            IsActive = true,
        //            points = 0
        //        },
        //        new Choice()
        //        {
        //            Id = 11,
        //            QuestionId = 5,
        //            Label = "This Choice Number 2 is for Question 5",
        //            IsActive = true,
        //            points = 4
        //        },
        //        new Choice()
        //        {
        //            Id = 12,
        //            QuestionId = 6,
        //            Label = "This Choice Number 1 is for Question 6",
        //            IsActive = true,
        //            points = 0
        //        },
        //        new Choice()
        //        {
        //            Id = 13,
        //            QuestionId = 6,
        //            Label = "This Choice Number 2 is for Question 6",
        //            IsActive = true,
        //            points = 4
        //        },
        //        new Choice()
        //        {
        //            Id = 14,
        //            QuestionId = 7,
        //            Label = "This Choice Number 1 is for Question 7",
        //            IsActive = true,
        //            points = 4
        //        },
        //        new Choice()
        //        {
        //            Id = 15,
        //            QuestionId = 7,
        //            Label = "This Choice Number 2 is for Question 7",
        //            IsActive = true,
        //            points = 0
        //        },
        //        new Choice()
        //        {
        //            Id = 16,
        //            QuestionId = 7,
        //            Label = "This Choice Number 3 is for Question 7",
        //            IsActive = true,
        //            points = 0
        //        },
        //        new Choice()
        //        {
        //            Id = 17,
        //            QuestionId = 8,
        //            Label = "This Choice Number 1 is for Question 8",
        //            IsActive = true,
        //            points = 0
        //        },
        //        new Choice()
        //        {
        //            Id = 18,
        //            QuestionId = 8,
        //            Label = "This Choice Number 2 is for Question 8",
        //            IsActive = true,
        //            points = 4
        //        },
        //        new Choice()
        //        {
        //            Id = 19,
        //            QuestionId = 9,
        //            Label = "This Choice Number 1 is for Question 9",
        //            IsActive = true,
        //            points = 4
        //        },
        //        new Choice()
        //        {
        //            Id = 20,
        //            QuestionId = 9,
        //            Label = "This Choice Number 2 is for Question 9",
        //            IsActive = true,
        //            points = 0
        //        },
        //        new Choice()
        //        {
        //            Id = 21,
        //            QuestionId = 10,
        //            Label = "This Choice Number 1 is for Question 10",
        //            IsActive = true,
        //            points = 4
        //        },
        //        new Choice()
        //        {
        //            Id = 22,
        //            QuestionId = 10,
        //            Label = "This Choice Number 2 is for Question 10",
        //            IsActive = true,
        //            points = 0
        //        },
        //        new Choice()
        //        {
        //            Id = 23,
        //            QuestionId = 11,
        //            Label = "This Choice Number 1 is for Question 11",
        //            IsActive = true,
        //            points = 1
        //        },
        //        new Choice()
        //        {
        //            Id = 24,
        //            QuestionId = 11,
        //            Label = "This Choice Number 2 is for Question 11",
        //            IsActive = true,
        //            points = 0
        //        },
        //        new Choice()
        //        {
        //            Id = 25,
        //            QuestionId = 11,
        //            Label = "This Choice Number 3 is for Question 11",
        //            IsActive = true,
        //            points = 3
        //        },
        //        new Choice()
        //        {
        //            Id = 26,
        //            QuestionId = 12,
        //            Label = "This Choice Number 1 is for Question 12",
        //            IsActive = true,
        //            points = 4
        //        },
        //        new Choice()
        //        {
        //            Id = 27,
        //            QuestionId = 12,
        //            Label = "This Choice Number 2 is for Question 12",
        //            IsActive = true,
        //            points = 0
        //        });
        }
    }
}
