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

namespace najjar.biz.Controllers
{
    public class UserVerificationLogController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();

        // GET: /UserVerificationLog/
        public ActionResult Index()
        {
            return View(db.UserVerificationLogs.ToList());
        }

        // GET: /UserVerificationLog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserVerificationLog userverificationlog = db.UserVerificationLogs.Find(id);
            if (userverificationlog == null)
            {
                return HttpNotFound();
            }
            return View(userverificationlog);
        }

        // GET: /UserVerificationLog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /UserVerificationLog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,CreationDate,LastModificationDate,ConfirmationDate,ExpiryDate,Code,Status,Email,IsEmailSent,UserId")] UserVerificationLog userverificationlog)
        {
            if (ModelState.IsValid)
            {
                db.UserVerificationLogs.Add(userverificationlog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userverificationlog);
        }

        // GET: /UserVerificationLog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserVerificationLog userverificationlog = db.UserVerificationLogs.Find(id);
            if (userverificationlog == null)
            {
                return HttpNotFound();
            }
            return View(userverificationlog);
        }

        // POST: /UserVerificationLog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,CreationDate,LastModificationDate,ConfirmationDate,ExpiryDate,Code,Status,Email,IsEmailSent,UserId")] UserVerificationLog userverificationlog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userverificationlog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userverificationlog);
        }

        // GET: /UserVerificationLog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserVerificationLog userverificationlog = db.UserVerificationLogs.Find(id);
            if (userverificationlog == null)
            {
                return HttpNotFound();
            }
            return View(userverificationlog);
        }

        // POST: /UserVerificationLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserVerificationLog userverificationlog = db.UserVerificationLogs.Find(id);
            db.UserVerificationLogs.Remove(userverificationlog);
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
    }
}
