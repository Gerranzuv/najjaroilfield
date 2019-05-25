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
    public class ContactUsController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();

        // GET: /ContactUs/
        public ActionResult Index()
        {
            return View(db.ContactUs.ToList());
        }

        // GET: /ContactUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactUs contactus = db.ContactUs.Find(id);
            if (contactus == null)
            {
                return HttpNotFound();
            }
            return View(contactus);
        }

        // GET: /ContactUs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ContactUs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,Name,Email,Message,Date")] ContactUs contactus)
        {
            if (ModelState.IsValid)
            {
                db.ContactUs.Add(contactus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactus);
        }

        // GET: /ContactUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactUs contactus = db.ContactUs.Find(id);
            if (contactus == null)
            {
                return HttpNotFound();
            }
            return View(contactus);
        }

        // POST: /ContactUs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,Name,Email,Message,Date")] ContactUs contactus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactus);
        }

        // GET: /ContactUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactUs contactus = db.ContactUs.Find(id);
            if (contactus == null)
            {
                return HttpNotFound();
            }
            return View(contactus);
        }

        // POST: /ContactUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactUs contactus = db.ContactUs.Find(id);
            db.ContactUs.Remove(contactus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult addMessage(ContactUs std)
        {
            std.Date= DateTime.UtcNow.Date;
            db.ContactUs.Add(std);
            db.SaveChanges();
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }


        public JsonResult getMessage(string id)
        {
            List<ContactUs> contactUss = new List<ContactUs>();
            contactUss = db.ContactUs.ToList();
            return Json(contactUss, JsonRequestBehavior.AllowGet);
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
