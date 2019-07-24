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

namespace najjar.biz.Controllers
{
    public class jobController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();

        // GET: /job/
        public ActionResult Index(string searchString,string status,string category)
        {
            fillUserData();
            var jobs = from s in db.Jobs
                       select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                jobs = jobs.Where(s => s.Title.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(status))
            {
                jobs = jobs.Where(s => s.Status.Equals(status));
            }
            if (!String.IsNullOrEmpty(category))
            {
                jobs = jobs.Where(s => s.Category.Contains(category));
            }
            //if (closingDate != null) {
            //    jobs = jobs.Where(s => s.ClosingDate.Equals(closingDate));
            //}

            return View(jobs.ToList());
        }
        // GET: /jobListForGuest/

        public ActionResult jobListForGuest()
        {

            return View(db.Jobs.ToList());
        }
        // GET: /job/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: /job/Create
        public ActionResult Create()
        {
            fillUserData();
            return View();
        }

        // POST: /job/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Job job)
        {
            fillUserData();
            if (ModelState.IsValid)
            {
                job.CreationDate = DateTime.Now;
                job.LastModificationDate = DateTime.Now;

                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(job);
        }

        // GET: /job/Edit/5
        public ActionResult Edit(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: /job/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,AnnouncementDate,ClosingDate,Title,Location,MilitaryService,Status,Category,Breifdescreption,Detaileddescreption,jobRequierment,AverageSalary")] Job job)
        {
            fillUserData();
            if (ModelState.IsValid)
            {
                Job oldJob = db.Jobs.Find(job.id);
                oldJob.AnnouncementDate = job.AnnouncementDate;
                oldJob.AverageSalary = job.AverageSalary;
                oldJob.Breifdescreption = job.Breifdescreption;
                oldJob.Category = job.Category;
                oldJob.ClosingDate = job.ClosingDate;
                oldJob.Detaileddescreption = job.Detaileddescreption;
                oldJob.jobRequierment = job.jobRequierment;
                oldJob.LastModificationDate = DateTime.Now;
                oldJob.Location = job.Location;
                oldJob.MilitaryService = job.MilitaryService;
                oldJob.Status = job.Status;
                oldJob.Title = job.Title;
                

                db.Entry(oldJob).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        // GET: /job/Delete/5
        public ActionResult Delete(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: /job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
    }

}
