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

namespace najjar.biz.Controllers.Systemutil
{
    public class PicklistItemController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();

        // GET: /PicklistItem/
        public ActionResult Index()
        {
            fillUserData();

            var picklistitems = db.PicklistItems.Include(p => p.FatherPickList);
            return View(picklistitems.ToList());
        }


        // GET: /ManageItems/
        public ActionResult ManageItems(int picklistid)
        {
            fillUserData();
            PicklistItem picklistItem = db.PicklistItems.Find(picklistid);
            if (picklistItem == null)
            {
                return HttpNotFound();
            }
            return View(picklistItem);
        }

        // GET: /PicklistItem/Details/5
        public ActionResult Details(int? id)
        {
            fillUserData();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PicklistItem picklistitem = db.PicklistItems.Find(id);
            if (picklistitem == null)
            {
                return HttpNotFound();
            }
            return View(picklistitem);
        }

        // GET: /PicklistItem/Create
        public ActionResult Create()
        {
            fillUserData();

            ViewBag.PicklistId = new SelectList(db.Picklists, "id", "Name");
            return View();
        }

        // POST: /PicklistItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,Name,Code,PicklistId,CreationDate,LastModificationDate,Creator,Modifier")] PicklistItem picklistitem)
        {
            fillUserData();


            if (ModelState.IsValid)
            {
                db.PicklistItems.Add(picklistitem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PicklistId = new SelectList(db.Picklists, "id", "Name", picklistitem.PicklistId);
            return View(picklistitem);
        }

        // GET: /PicklistItem/Edit/5
        public ActionResult Edit(int? id)
        {


            fillUserData();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PicklistItem picklistitem = db.PicklistItems.Find(id);
            if (picklistitem == null)
            {
                return HttpNotFound();
            }
            ViewBag.PicklistId = new SelectList(db.Picklists, "id", "Name", picklistitem.PicklistId);
            return View(picklistitem);
        }

        // POST: /PicklistItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,Name,Code,PicklistId,CreationDate,LastModificationDate,Creator,Modifier")] PicklistItem picklistitem)
        {
            fillUserData();

            if (ModelState.IsValid)
            {
                db.Entry(picklistitem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PicklistId = new SelectList(db.Picklists, "id", "Name", picklistitem.PicklistId);
            return View(picklistitem);
        }

        // GET: /PicklistItem/Delete/5
        public ActionResult Delete(int? id)
        {

            fillUserData();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PicklistItem picklistitem = db.PicklistItems.Find(id);
            if (picklistitem == null)
            {
                return HttpNotFound();
            }
            return View(picklistitem);
        }

        // POST: /PicklistItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fillUserData();

            PicklistItem picklistitem = db.PicklistItems.Find(id);
            db.PicklistItems.Remove(picklistitem);
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
