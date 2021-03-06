﻿using System;
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
    public class RegistrationController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();

        // GET: /Registration/
        public ActionResult Index(int? page)
        {
            fillUserData();
            var registrations = db.Registrations.Include(r => r.Employee).Include(r => r.Test).OrderByDescending(r=>r.RegistrationDate);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(registrations.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Registration/Details/5
        public ActionResult Details(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // GET: /Registration/Create
        public ActionResult Create()
        {
            fillUserData();
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name");
            ViewBag.TestId = new SelectList(db.Tests, "Id", "Name");
            return View();
        }

        // POST: /Registration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,RegistrationDate,ExpiresDate,Token,TestId,EmployeeId")] Registration registration)
        {
            fillUserData();
            if (ModelState.IsValid)
            {
                db.Registrations.Add(registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", registration.EmployeeId);
            ViewBag.TestId = new SelectList(db.Tests, "Id", "Name", registration.TestId);
            return View(registration);
        }

        // GET: /Registration/Edit/5
        public ActionResult Edit(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", registration.EmployeeId);
            ViewBag.TestId = new SelectList(db.Tests, "Id", "Name", registration.TestId);
            return View(registration);
        }

        // POST: /Registration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,RegistrationDate,ExpiresDate,Token,TestId,EmployeeId")] Registration registration)
        {
            fillUserData();
            if (ModelState.IsValid)
            {
                db.Entry(registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Name", registration.EmployeeId);
            ViewBag.TestId = new SelectList(db.Tests, "Id", "Name", registration.TestId);
            return View(registration);
        }

        // GET: /Registration/Delete/5
        public ActionResult Delete(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // POST: /Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fillUserData();
            Registration registration = db.Registrations.Find(id);
            db.Registrations.Remove(registration);
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
