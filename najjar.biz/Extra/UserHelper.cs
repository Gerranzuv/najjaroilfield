using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using najjar.biz.Context;
using najjar.biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace najjar.biz.Extra
{
    public class UserHelper:Controller
    {
        private static ApplicationDataContext db = new ApplicationDataContext();

        public ApplicationUser getCurrentUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDataContext()));
            ApplicationUser user = userManager.FindById(User.Identity.GetUserId());
            return user;
        }
    }
}