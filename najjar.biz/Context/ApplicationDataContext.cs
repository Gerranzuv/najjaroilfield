using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using najjar.biz.Models;
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

        public System.Data.Entity.DbSet<najjar.biz.Models.Employees> Employees { get; set; }

        public System.Data.Entity.DbSet<najjar.biz.Models.Support> Supports { get; set; }

        public System.Data.Entity.DbSet<najjar.biz.Models.FileDetail> FileDetails { get; set; }

        public System.Data.Entity.DbSet<najjar.biz.Models.Articles> Articles { get; set; }

        public System.Data.Entity.DbSet<najjar.biz.Models.RoleViewModel> RoleViewModels { get; set; }

        public System.Data.Entity.DbSet<najjar.biz.Models.ContactUs> ContactUs { get; set; }

        public System.Data.Entity.DbSet<najjar.biz.Models.ArticleComment> ArticleComments { get; set; }

        public System.Data.Entity.DbSet<najjar.biz.Models.Job> Jobs { get; set; }

        public System.Data.Entity.DbSet<najjar.biz.Models.JobRequest> JobRequests { get; set; }

        public System.Data.Entity.DbSet<najjar.biz.Models.EmployeesVacation> EmployeesVacations { get; set; }

        public System.Data.Entity.DbSet<najjar.biz.Models.EmployeeRating> EmployeeRatings { get; set; }
    }
}