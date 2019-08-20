using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using najjar.biz.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace najjar.biz.Context
{
    public class ApplicationDataContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDataContext()
            : base("DefaultConnection")
        {
            //System.Data.Entity.Database.SetInitializer<ApplicationDataContext>(null);

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Properties<DateTime>()
                .Configure(p => p.HasColumnType("datetime2"));
        }

        public DbSet<Employees> Employees { get; set; }

        public DbSet<Support> Supports { get; set; }

        public DbSet<FileDetail> FileDetails { get; set; }

        public DbSet<Articles> Articles { get; set; }

        public DbSet<RoleViewModel> RoleViewModels { get; set; }

        public DbSet<ContactUs> ContactUs { get; set; }

        public DbSet<ArticleComment> ArticleComments { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<JobRequest> JobRequests { get; set; }

        public DbSet<EmployeesVacation> EmployeesVacations { get; set; }

        public DbSet<EmployeeRating> EmployeeRatings { get; set; }

        // Online Exam System Entities

        public DbSet<Registration> Registrations { get; set; }

        public DbSet<QuestionCategory> QuestionCategories { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Test> Tests { get; set; }

        public DbSet<Choice> Choices { get; set; }

        public DbSet<TestXPaper> TestXPapers { get; set; }

        public DbSet<TestXQuestion> TestXQuestions { get; set; }

        public DbSet<QuestionXDuration> QuestionXDurations { get; set; }

        public System.Data.Entity.DbSet<najjar.biz.Models.SystemParameter> SystemParameters { get; set; }

        public System.Data.Entity.DbSet<najjar.biz.Models.EmailLog> EmailLogs { get; set; }

        public System.Data.Entity.DbSet<najjar.biz.Models.UserVerificationLog> UserVerificationLogs { get; set; }

        public System.Data.Entity.DbSet<najjar.biz.Models.EmployeeProspect> EmployeeProspects { get; set; }

        public System.Data.Entity.DbSet<najjar.biz.Models.WorkExperience> WorkExperiences { get; set; }
        public System.Data.Entity.DbSet<najjar.biz.Models.Certification> Certifications { get; set; }

        public System.Data.Entity.DbSet<najjar.biz.Models.Language> Languages { get; set; }

        public System.Data.Entity.DbSet<najjar.biz.Models.Skill> Skills { get; set; }


    }
}