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
            var picklistitems = db.PicklistItems.Where(p => p.PicklistId == (picklistid)).Include(p => p.FatherPickList);
            return View(picklistitems.ToList());
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
        public ActionResult Create(int picklistid)
        {
            fillUserData();

            ViewBag.picklistid = new SelectList(db.Picklists, "id", "Name");
            return View();
        }

        // POST: /PicklistItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PicklistItem std)
        {
            std.CreationDate = DateTime.Now;
            std.LastModificationDate = DateTime.Now;
            std.Creator = getCurrentUser().Id;
            std.Modifier = getCurrentUser().Id;
            //fatherid = std.getpicklistId;
            Picklist picklist = db.Picklists.Find(std.PicklistId);
            std.FatherPickList = picklist;
            db.PicklistItems.Add(std);
            if (ModelState.IsValid)
            {

                db.SaveChanges();
                return RedirectToAction("ManageItems", new { picklistid = std.PicklistId });

            }

            return View();
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
        public ActionResult Edit( PicklistItem std)
        {
            fillUserData();

            PicklistItem toEdit = db.PicklistItems.Find(std.id);
           
            if (ModelState.IsValid)
            {
                toEdit.Name = std.Name;
                toEdit.Code = std.Code;
                toEdit.LastModificationDate = DateTime.Now;
                toEdit.Modifier = getCurrentUser().Id;
                db.Entry(toEdit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManageItems", new { picklistid = toEdit.PicklistId });
            }
            return RedirectToAction("ManageItems", new { picklistid = toEdit.PicklistId });
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
            return RedirectToAction("ManageItems", new { picklistid = picklistitem.PicklistId });
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

        public ApplicationUser getCurrentUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDataContext()));
            ApplicationUser user = userManager.FindById(User.Identity.GetUserId());
            return user;
        }
    }
}
