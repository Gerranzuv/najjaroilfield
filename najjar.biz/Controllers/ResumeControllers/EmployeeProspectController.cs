using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using najjar.biz.Models;
using najjar.biz.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Validation;

namespace najjar.biz.Controllers.ResumeControllers
{
    public class EmployeeProspectController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();

        // GET: /EmployeeProspect/
        public async Task<ActionResult> Index()
        {
            fillUserData();
            return View(await db.EmployeeProspects.ToListAsync());
        }

        // GET: /EmployeeProspect/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeProspect employeeprospect = await db.EmployeeProspects.FindAsync(id);
            if (employeeprospect == null)
            {
                return HttpNotFound();
            }
            return View(employeeprospect);
        }

        // GET: /EmployeeProspect/Create
        public ActionResult Create()
        {
            fillUserData();
            return View();
        }

        // POST: /EmployeeProspect/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="id,CreationDate,LastModificationDate,Name,Address,AddressInArabic,Email,EmployeeImage,Nationality,BirthDate,Sex,BirthPlace")] EmployeeProspect employeeprospect)
        {
            fillUserData();
            if (ModelState.IsValid)
            {
                db.EmployeeProspects.Add(employeeprospect);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(employeeprospect);
        }

        // GET: /EmployeeProspect/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeProspect employeeprospect = await db.EmployeeProspects.FindAsync(id);
            if (employeeprospect == null)
            {
                return HttpNotFound();
            }
            return View(employeeprospect);
        }

        // POST: /EmployeeProspect/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="id,CreationDate,LastModificationDate,Name,Address,AddressInArabic,Email,EmployeeImage,Nationality,BirthDate,Sex,BirthPlace")] EmployeeProspect employeeprospect)
        {
            fillUserData();
            if (ModelState.IsValid)
            {
                db.Entry(employeeprospect).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employeeprospect);
        }

        // GET: /EmployeeProspect/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeProspect employeeprospect = await db.EmployeeProspects.FindAsync(id);
            if (employeeprospect == null)
            {
                return HttpNotFound();
            }
            return View(employeeprospect);
        }

        // POST: /EmployeeProspect/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            fillUserData();
            EmployeeProspect employeeprospect = await db.EmployeeProspects.FindAsync(id);
            db.EmployeeProspects.Remove(employeeprospect);
            await db.SaveChangesAsync();
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

        [HttpPost]
        public ActionResult addWorkExperience(WorkExperience std)
        {
            std.CreationDate = DateTime.Now;
            std.LastModificationDate = DateTime.Now;
            std.EmployeeProspectId = (int)std.EmployeeProspectId;
            db.WorkExperiences.Add(std);
            try { db.SaveChanges(); }
            catch (DbEntityValidationException e) {
                string message1 = e.StackTrace;
                foreach (var eve in e.EntityValidationErrors)
                {

                    message1 += eve.Entry.State +"\n";
                    foreach (var ve in eve.ValidationErrors)
                    {
                        message1+=String.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                        message1+="\n";
                    }
                }
                return Json(new { Message = message1, JsonRequestBehavior.AllowGet });
            }
            
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        public JsonResult getWorkExperiences(int id)
        {
            return Json(db.WorkExperiences.Where(a => a.EmployeeProspectId.Equals(id)).ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult deleteWorkExperience(int id) {
            WorkExperience toDelete = db.WorkExperiences.Where(a => a.id.Equals(id)).FirstOrDefault();
            db.WorkExperiences.Remove(toDelete);
            try { db.SaveChanges(); }
            catch (DbEntityValidationException e)
            {
                string message1 = e.StackTrace;
                foreach (var eve in e.EntityValidationErrors)
                {

                    message1 += eve.Entry.State + "\n";
                    foreach (var ve in eve.ValidationErrors)
                    {
                        message1 += String.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                        message1 += "\n";
                    }
                }
                return Json(new { Message = message1, JsonRequestBehavior.AllowGet });
            }

            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpDelete]
        public JsonResult deleteItem(int id)
        {
            
            return Json("Response from Delete");
        }

        // GET: /EmployeeProspect/AddNew
        public ActionResult AddNew()
        {
            fillUserData();
            return View();
        }

        [HttpPost]
        public ActionResult editWorkExperience(WorkExperience std)
        {
            WorkExperience toEdit = db.WorkExperiences.Where(a => a.id == std.id).FirstOrDefault() ;
            if (toEdit == null)
                return Json("No Matching record");
            toEdit.Position = std.Position;
            toEdit.Description = std.Description;
            toEdit.From = std.From;
            toEdit.To = std.To;
            toEdit.LastModificationDate = DateTime.Now;
            db.Entry(toEdit).State = EntityState.Modified;
            try { db.SaveChanges(); }
            catch (DbEntityValidationException e)
            {
                string message1 = e.StackTrace;
                foreach (var eve in e.EntityValidationErrors)
                {

                    message1 += eve.Entry.State + "\n";
                    foreach (var ve in eve.ValidationErrors)
                    {
                        message1 += String.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                        message1 += "\n";
                    }
                }
                return Json(new { Message = message1, JsonRequestBehavior.AllowGet });
            }

            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        // POST: /EmployeeProspect/AddNew
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddNew(EmployeeProspect employeeprospect)
        {
            fillUserData();
            if (ModelState.IsValid)
            {
                employeeprospect.CreationDate = DateTime.Now;
                employeeprospect.LastModificationDate = DateTime.Now; ;

                db.EmployeeProspects.Add(employeeprospect);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(employeeprospect);
        }

    }
}
