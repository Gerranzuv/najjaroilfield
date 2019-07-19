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
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace najjar.biz.Controllers
{
    public class jobRequestController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();

        // GET: /jobRequest/
        public ActionResult Index()
        {
            fillUserData();
            return View(db.JobRequests.ToList());
        }

        // GET: /jobRequest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobRequest jobrequest = db.JobRequests.Find(id);
            if (jobrequest == null)
            {
                return HttpNotFound();
            }
            return View(jobrequest);
        }

        // GET: /jobRequest/Create
        public ActionResult Create(int? jobId)
        {
            JobRequest request = new JobRequest();
            if (jobId != null)
            {
                Job job = db.Jobs.Single(j => j.id == jobId);
                request.jobName = job.Title;
                request.JobId = job.id;
            }
            return View(request);
        }

        // POST: /jobRequest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobRequest jobrequest, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), upload.FileName);
                upload.SaveAs(path);
                jobrequest.FilePath = upload.FileName;
                jobrequest.CreationDate = DateTime.Now;
                jobrequest.LastModificationDate = DateTime.Now;
                //Job job = db.Jobs.Find(jobrequest.JobId);
                //jobrequest.jobName = job.Title;
                db.JobRequests.Add(jobrequest);

                db.SaveChanges();
                return RedirectToAction("jobListForGuest", "Job");
            }

            return View(jobrequest);
        }

        // GET: /jobRequest/Edit/5
        public ActionResult Edit(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobRequest jobrequest = db.JobRequests.Find(id);
            if (jobrequest == null)
            {
                return HttpNotFound();
            }
            return View(jobrequest);
        }

        // POST: /jobRequest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,PhoneNumber,JobId,EmailAddress,FirstName,LastName,FilePath")] JobRequest jobrequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobrequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobrequest);
        }

        // GET: /jobRequest/Delete/5
        public ActionResult Delete(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobRequest jobrequest = db.JobRequests.Find(id);
            if (jobrequest == null)
            {
                return HttpNotFound();
            }
            return View(jobrequest);
        }

        // POST: /jobRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobRequest jobrequest = db.JobRequests.Find(id);
            db.JobRequests.Remove(jobrequest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public virtual ActionResult Download(string FilePath)
        {
            //fileName should be like "photo.jpg"
            string fullPath = Path.Combine(Server.MapPath("~/Images/"), FilePath);
            return File(fullPath, "application/octet-stream", FilePath);
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
