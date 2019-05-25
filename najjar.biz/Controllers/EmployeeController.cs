using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using najjar.biz.Models;
using PagedList;
using System.IO;

using najjar.biz.Context;
namespace najjar.biz.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();

        [Authorize]
        // GET: /Employee/
        
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            //Initialize viewBag with search parameters
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            //Get full list of employees
            var employees = from s in db.Employees
                            select s;
            //Filter result by name
            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.Name.Contains(searchString));
            }

            //code for sorting result by employee joining date or name
            switch (sortOrder)
            {
                // Sorting by name descinding
                case "name_desc":
                    employees = employees.OrderByDescending(s => s.Name);
                    break;

                // Sorting by joining date ascinding
                case "Date":
                    employees = employees.OrderBy(s => s.StartDate);
                    break;

                // Sorting by joining date descinding
                case "date_desc":
                    employees = employees.OrderByDescending(s => s.StartDate);
                    break;

                // Default sort is by name ascinding
                default:
                    employees = employees.OrderBy(s => s.Name);
                    break;
            }

            //return result
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(employees.ToPagedList(pageNumber, pageSize));
        }



        [Authorize]
        public ActionResult EmployeesPage(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            //Initialize viewBag with search parameters
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            //Get full list of employees
            var employees = from s in db.Employees
                            select s;
            //Filter result by name
            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.Name.Contains(searchString));
            }

            //code for sorting result by employee joining date or name
            switch (sortOrder)
            {
                // Sorting by name descinding
                case "name_desc":
                    employees = employees.OrderByDescending(s => s.Name);
                    break;

                // Sorting by joining date ascinding
                case "Date":
                    employees = employees.OrderBy(s => s.StartDate);
                    break;

                // Sorting by joining date descinding
                case "date_desc":
                    employees = employees.OrderByDescending(s => s.StartDate);
                    break;

                // Default sort is by name ascinding
                default:
                    employees = employees.OrderBy(s => s.Name);
                    break;
            }

            //return result
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(employees.ToPagedList(pageNumber, pageSize));
        }


        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            int Id = employees.Id;
            string oldpath = employees.EmployeeImage;
            //////////////////////////////////////////
            ViewData["Id"] = Id;
            ViewData["oldpath"] = oldpath;
            //////////////////////////////////////
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        [Authorize]
        public ActionResult Employeecv(int Employeeid)
        {
            if (Employeeid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(Employeeid);
            if (employees == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employeeid = Employeeid;
            return View(employees);

        }



        [Authorize]
        public ActionResult SalaryInfo(int Employeeid)
        {
            if (Employeeid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(Employeeid);
            if (employees == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employeeid = Employeeid;
            return View(employees);
        }



        [Authorize]
        // GET: /Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            Session["EmpId"] = id;
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // GET: /Employee/PersonalPage/5


        [Authorize]
        public ActionResult PersonalPage(int Employeeid)
        {
            if (Employeeid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(Employeeid);
            if (employees == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employeeid = Employeeid;
            return View(employees);
        }



        [Authorize]
        // GET: /Employee/Create
        public ActionResult Create()
        {
            return View();
        }


        [Authorize]
        // GET: /Employee/AddNewEmployee
        public ActionResult AddNewEmployee()
        {
            return View();
        }

       

       
        

        // POST: /Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employees employees, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null)
                {
                    var depMap = new Dictionary<String, String>();
                    depMap.Add("Management", "01");
                    depMap.Add("HR", "02");
                    depMap.Add("IT", "03");
                    depMap.Add("Accounting", "04");
                    depMap.Add("Marketing & Selling", "05");
                    depMap.Add("Quality Management", "06");
                    depMap.Add("HSE", "07");
                    depMap.Add("WireLine", "08");
                    depMap.Add("Sickline", "09");
                    depMap.Add("Coiled Tubing", "10");
                    depMap.Add("SRAC Bumping", "11");
                    depMap.Add("Drilling", "12");
                    depMap.Add("Testing", "13");

                    var countryMap = new Dictionary<String, String>();
                    countryMap.Add("Syria", "63");
                    countryMap.Add("Lebanon", "61");
                    countryMap.Add("Egypt", "20");

                    string month = employees.StartDate.ToString("MM");
                    string year = employees.StartDate.ToString("yy");

                    employees.EmployeeCode = depMap[employees.Department] + month + year + countryMap[employees.Country] + employees.EId;


                    string path = Path.Combine(Server.MapPath("~/Images"), upload.FileName);
                    upload.SaveAs(path);
                    employees.EmployeeImage = upload.FileName;
                    employees.creationDate = DateTime.Now;

                    db.Employees.Add(employees);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(employees);
        }

        

        // POST: /Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Employees employees, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string oldpath = employees.EmployeeImage;
                if (upload != null)
                {
                    System.IO.File.Delete(oldpath);
                    string path = Path.Combine(Server.MapPath("~/Images"), upload.FileName);
                    upload.SaveAs(path);
                    var depMap = new Dictionary<String, String>();
                    depMap.Add("Management", "01");
                    depMap.Add("HR", "02");
                    depMap.Add("IT", "03");
                    depMap.Add("Accounting", "04");
                    depMap.Add("Marketing & Selling", "05");
                    depMap.Add("Quality Management", "06");
                    depMap.Add("HSE", "07");
                    depMap.Add("WireLine", "08");
                    depMap.Add("Sickline", "09");
                    depMap.Add("Coiled Tubing", "10");
                    depMap.Add("SRAC Bumping", "11");
                    depMap.Add("Drilling", "12");
                    depMap.Add("Testing", "13");

                    var countryMap = new Dictionary<String, String>();
                    countryMap.Add("Syria", "63");
                    countryMap.Add("Lebanon", "61");
                    countryMap.Add("Egypt", "20");

                    string month = employees.StartDate.ToString("MM");
                    string year = employees.StartDate.ToString("yy");

                    employees.EmployeeCode = depMap[employees.Department] + month + year + countryMap[employees.Country] + employees.EId;
                    employees.EmployeeImage = upload.FileName;
                    employees.lastModificationDate = DateTime.Now;
                    db.Entry(employees).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("PersonalPage", new { Employeeid = employees.Id });
                }
            }
            return View(employees);
        }


        [Authorize]
        // GET: /Employee/EmpCV/5
        public ActionResult EmpCV(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            Session["EmpId"] = id;
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // GET: /Employee/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        [Authorize]
        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employees employees = db.Employees.Find(id);
            db.Employees.Remove(employees);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        [Authorize]
        // GET: /Employee/editsalary
        public ActionResult EditSalary(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }





        //edit salary--post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateSalary([Bind(Include = "id,startDate,EndDate,Status")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                Employees employee = db.Employees.Find(employees.Id);
                //employee.StartDate = employees.StartDate;
                //employee.EndDate = employees.EndDate;
                //employee.Status = employees.Status;
                //employee.Duration = (employee.EndDate - employee.startDate).Days;
                //employee.LastModificationDate = DateTime.Now;
                //db.Entry(employee).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("SalaryInfo", new { Employeeid = employee.Id });
            }
            return View(employees);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [Authorize]
        public FileResult Download(String p, String d)
        {
            return File(Path.Combine(Server.MapPath("~/Images/"), p), System.Net.Mime.MediaTypeNames.Application.Octet, d);
        }


    }



}
