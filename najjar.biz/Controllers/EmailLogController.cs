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
using PagedList;

namespace najjar.biz.Controllers
{
    public class EmailLogController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();

        // GET: /EmailLog/
        public ActionResult Index(int? page)
        {
            fillUserData();
            var EmailLogs = db.EmailLogs.OrderByDescending(r => r.CreationDate);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(EmailLogs.ToPagedList(pageNumber, pageSize));
        } 

        // GET: /EmailLog/Details/5
        public ActionResult Details(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailLog emaillog = db.EmailLogs.Find(id);
            if (emaillog == null)
            {
                return HttpNotFound();
            }
            return View(emaillog);
        }

        // GET: /EmailLog/Create
        public ActionResult Create()
        {
            fillUserData();
            return View();
        }

        // POST: /EmailLog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Sender,Receiver,Subject,Body,CreationDate,LastModificationDate")] EmailLog emaillog)
        {
            fillUserData();
            if (ModelState.IsValid)
            {
                db.EmailLogs.Add(emaillog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emaillog);
        }

        // GET: /EmailLog/Edit/5
        public ActionResult Edit(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailLog emaillog = db.EmailLogs.Find(id);
            if (emaillog == null)
            {
                return HttpNotFound();
            }
            return View(emaillog);
        }

        // POST: /EmailLog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Sender,Receiver,Subject,Body,CreationDate,LastModificationDate")] EmailLog emaillog)
        {
            fillUserData();
            if (ModelState.IsValid)
            {
                db.Entry(emaillog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emaillog);
        }

        // GET: /EmailLog/Delete/5
        public ActionResult Delete(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailLog emaillog = db.EmailLogs.Find(id);
            if (emaillog == null)
            {
                return HttpNotFound();
            }
            return View(emaillog);
        }

        // POST: /EmailLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fillUserData();
            EmailLog emaillog = db.EmailLogs.Find(id);
            db.EmailLogs.Remove(emaillog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            fillUserData();
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
