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
    public class EmployeeRatingController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();

        
        // GET: /EmployeeRating/
        public ActionResult Index()
        {
            return View(db.EmployeeRatings.ToList());
        }


        
        public ActionResult EmployeeRating(int Employeeid)
        {
            return View(db.EmployeeRatings.Where(x => x.EmployeeId == Employeeid).ToList());
        }


        
        // GET: /EmployeeRating/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRating employeerating = db.EmployeeRatings.Find(id);
            if (employeerating == null)
            {
                return HttpNotFound();
            }
            return View(employeerating);
        }

        
        // GET: /EmployeeRating/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: /EmployeeRating/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,Year,Rating,Status,EmployeeId")] EmployeeRating employeerating)
        {
            if (ModelState.IsValid)
            {
                employeerating.CreationDate = DateTime.Now;
                employeerating.LastModificationDate = DateTime.Now;
                var map = new Dictionary<string, Double>();
                map.Add("A", 50000);
                map.Add("B", 40000);
                map.Add("C", 30000);
                map.Add("D", 20000);
                map.Add("E", 10000);
                map.Add("F", 5000);
                //Update employee Salary with the rating
                if (employeerating.Status.Equals("Confirmed"))
                {
                    Employees employee = db.Employees.Find(employeerating.EmployeeId);
                    employeerating.SalaryBeforeUpdate = employee.TotalSalary;
                    employee.TotalSalary += map[employeerating.Rating];
                    employee.lastModificationDate = DateTime.Now;
                    db.Entry(employee).State = EntityState.Modified;
                    db.SaveChanges();

                    employeerating.SalaryAfterUpdate = employee.TotalSalary;
                }
                else {
                    Employees employee = db.Employees.Find(employeerating.EmployeeId);
                    employeerating.SalaryBeforeUpdate = employee.TotalSalary;
                    employeerating.SalaryAfterUpdate = employee.TotalSalary;
                }

                db.EmployeeRatings.Add(employeerating);
                db.SaveChanges();
                return RedirectToAction("EmployeeRating", new { Employeeid = employeerating.EmployeeId });
            }

            return View(employeerating);
        }

        // GET: /EmployeeRating/Edit/5
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRating employeerating = db.EmployeeRatings.Find(id);
            if (employeerating == null)
            {
                return HttpNotFound();
            }
            return View(employeerating);
        }

        // POST: /EmployeeRating/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,Year,Rating,Status")] EmployeeRating employeerating)
        {
            if (ModelState.IsValid)
            {
                EmployeeRating oldRating = db.EmployeeRatings.Find(employeerating.id);
                oldRating.Year = employeerating.Year;
                oldRating.Rating = employeerating.Rating;
                oldRating.Status = employeerating.Status;
                oldRating.LastModificationDate = DateTime.Now;
                db.Entry(oldRating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EmployeeRating", new { Employeeid = oldRating.EmployeeId });
            }
            return View(employeerating);
        }

        // GET: /EmployeeRating/Delete/5
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeRating employeerating = db.EmployeeRatings.Find(id);
            if (employeerating == null)
            {
                return HttpNotFound();
            }
            return View(employeerating);
        }

        // POST: /EmployeeRating/Delete/5
        [HttpPost, ActionName("Delete")]
        
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeRating employeerating = db.EmployeeRatings.Find(id);
            db.EmployeeRatings.Remove(employeerating);
            db.SaveChanges();
            return RedirectToAction("EmployeeRating", new { Employeeid = employeerating.EmployeeId });
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
