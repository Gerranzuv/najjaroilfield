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
    public class EmployeesVacationController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();

        // GET: /EmployeesVacation/
        public ActionResult Index()
        {
            fillUserData();
            return View(db.EmployeesVacations.ToList());
        }

        // GET: /EmployeesVacation/
        public ActionResult EmployeeVacation(int  Employeeid)
        {
            fillUserData();
            return View(db.EmployeesVacations.Where(x => x.EmployeeId == Employeeid).ToList());
        }


        // GET: /EmployeesVacation/Details/5
        public ActionResult Details(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeesVacation employeesvacation = db.EmployeesVacations.Find(id);
            if (employeesvacation == null)
            {
                return HttpNotFound();
            }
            return View(employeesvacation);
        }

        // GET: /EmployeesVacation/Create
        public ActionResult Create()
        {
            fillUserData();
            return View();
        }

        // POST: /EmployeesVacation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,startDate,EndDate,Duration,EmployeeId,Status")] EmployeesVacation employeesvacation)
        {
            if (ModelState.IsValid)
            {
                employeesvacation.CreationDate = DateTime.Now;
                employeesvacation.LastModificationDate = DateTime.Now;
                employeesvacation.Duration = (employeesvacation.EndDate - employeesvacation.startDate).Days ;
                db.EmployeesVacations.Add(employeesvacation);
                db.SaveChanges();
                return RedirectToAction("EmployeeVacation", new { Employeeid = employeesvacation.EmployeeId});
            }

            return View(employeesvacation);
        }

        // GET: /EmployeesVacation/Edit/5
        public ActionResult Edit(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeesVacation employeesvacation = db.EmployeesVacations.Find(id);
            if (employeesvacation == null)
            {
                return HttpNotFound();
            }
            return View(employeesvacation);
        }

        // POST: /EmployeesVacation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,startDate,EndDate,Status")] EmployeesVacation employeesvacation)
        {
            if (ModelState.IsValid)
            {
                EmployeesVacation vacOld = db.EmployeesVacations.Find(employeesvacation.id);
                vacOld.startDate = employeesvacation.startDate;
                vacOld.EndDate = employeesvacation.EndDate;
                vacOld.Status = employeesvacation.Status;
                vacOld.Duration = (vacOld.EndDate - vacOld.startDate).Days;
                vacOld.LastModificationDate = DateTime.Now;
                db.Entry(vacOld).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EmployeeVacation", new { Employeeid = vacOld.EmployeeId });
            }
            return View(employeesvacation);
        }

        // GET: /EmployeesVacation/Delete/5
        public ActionResult Delete(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeesVacation employeesvacation = db.EmployeesVacations.Find(id);
            if (employeesvacation == null)
            {
                return HttpNotFound();
            }
            return View(employeesvacation);
        }

        // POST: /EmployeesVacation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeesVacation employeesvacation = db.EmployeesVacations.Find(id);
            db.EmployeesVacations.Remove(employeesvacation);
            db.SaveChanges();
            return RedirectToAction("EmployeeVacation", new { Employeeid = employeesvacation.EmployeeId });
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
