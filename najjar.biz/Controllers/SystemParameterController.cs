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
    public class SystemParameterController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();

        // GET: /SystemParameter/
        public ActionResult Index()
        {
            fillUserData();
            return View(db.SystemParameters.ToList());
        }

        // GET: /SystemParameter/Details/5
        public ActionResult Details(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemParameter systemparameter = db.SystemParameters.Find(id);
            if (systemparameter == null)
            {
                return HttpNotFound();
            }
            return View(systemparameter);
        }

        // GET: /SystemParameter/Create
        public ActionResult Create()
        {
            fillUserData();
            return View();
        }

        // POST: /SystemParameter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,Name,Code,Value")] SystemParameter systemparameter)
        {
            fillUserData();
            if (ModelState.IsValid)
            {
                systemparameter.CreationDate = DateTime.Now;
                systemparameter.LastModificationDate = DateTime.Now;
                db.SystemParameters.Add(systemparameter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(systemparameter);
        }

        // GET: /SystemParameter/Edit/5
        public ActionResult Edit(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemParameter systemparameter = db.SystemParameters.Find(id);
            if (systemparameter == null)
            {
                return HttpNotFound();
            }
            return View(systemparameter);
        }

        // POST: /SystemParameter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,Name,Code,Value")] SystemParameter systemparameter)
        {
            fillUserData();
            if (ModelState.IsValid)
            {
                SystemParameter origin= db.SystemParameters.Where(y => y.id == systemparameter.id).First();
                origin.Name = systemparameter.Name;
                origin.Code = systemparameter.Code;
                origin.Value = systemparameter.Value;
                origin.LastModificationDate = DateTime.Now;
                db.Entry(origin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(systemparameter);
        }

        // GET: /SystemParameter/Delete/5
        public ActionResult Delete(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemParameter systemparameter = db.SystemParameters.Find(id);
            if (systemparameter == null)
            {
                return HttpNotFound();
            }
            return View(systemparameter);
        }

        // POST: /SystemParameter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SystemParameter systemparameter = db.SystemParameters.Find(id);
            db.SystemParameters.Remove(systemparameter);
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
