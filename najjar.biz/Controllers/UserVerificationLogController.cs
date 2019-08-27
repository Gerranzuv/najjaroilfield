using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using najjar.biz.Models;
using najjar.biz.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Validation;
using najjar.biz.Extra;
using System.IO;
using PagedList;


namespace najjar.biz.Controllers
{
    public class UserVerificationLogController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();

        // GET: /UserVerificationLog/
        public ActionResult Index(int? page)
        {
            fillUserData();
            var userVerificationLogs = db.UserVerificationLogs.OrderByDescending(r => r.LastModificationDate );
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(userVerificationLogs.ToPagedList(pageNumber, pageSize));
        }

        // GET: /UserVerificationLog/Details/5
       

        // GET: /UserVerificationLog/Create
     

        // POST: /UserVerificationLog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
      
        // GET: /UserVerificationLog/Edit/5
      
        // POST: /UserVerificationLog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
     

        // GET: /UserVerificationLog/Delete/5
     

        // POST: /UserVerificationLog/Delete/5
      

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public void fillUserData()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDataContext()));
            var user = userManager.FindById(User.Identity.GetUserId());
            ViewBag.CurrentUser = user;
        }

        public ApplicationUser getCurrentUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDataContext()));
            ApplicationUser user = userManager.FindById(User.Identity.GetUserId());
            return user;
        }
    }


}
