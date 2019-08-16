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

namespace najjar.biz.Controllers.ResumeControllers
{
    public class WorkExperienceController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();

        // GET: /WorkExperience/
        public async Task<ActionResult> Index()
        {
            fillUserData();
            var workexperiences = db.WorkExperiences.Include(w => w.EmployeePros);
            return View(await workexperiences.ToListAsync());
        }

        // GET: /WorkExperience/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkExperience workexperience = await db.WorkExperiences.FindAsync(id);
            if (workexperience == null)
            {
                return HttpNotFound();
            }
            return View(workexperience);
        }

        // GET: /WorkExperience/Create
        public ActionResult Create()
        {
            fillUserData();
            ViewBag.EmployeeProspectId = new SelectList(db.EmployeeProspects, "id", "Name");
            return View();
        }

        // POST: /WorkExperience/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="id,CreationDate,LastModificationDate,From,To,Position,Description,EmployeeProspectId")] WorkExperience workexperience)
        {
            fillUserData();
            if (ModelState.IsValid)
            {
                db.WorkExperiences.Add(workexperience);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeProspectId = new SelectList(db.EmployeeProspects, "id", "Name", workexperience.EmployeeProspectId);
            return View(workexperience);
        }

        // GET: /WorkExperience/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkExperience workexperience = await db.WorkExperiences.FindAsync(id);
            if (workexperience == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeProspectId = new SelectList(db.EmployeeProspects, "id", "Name", workexperience.EmployeeProspectId);
            return View(workexperience);
        }

        // POST: /WorkExperience/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="id,CreationDate,LastModificationDate,From,To,Position,Description,EmployeeProspectId")] WorkExperience workexperience)
        {
            fillUserData();
            if (ModelState.IsValid)
            {
                db.Entry(workexperience).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeProspectId = new SelectList(db.EmployeeProspects, "id", "Name", workexperience.EmployeeProspectId);
            return View(workexperience);
        }

        // GET: /WorkExperience/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkExperience workexperience = await db.WorkExperiences.FindAsync(id);
            if (workexperience == null)
            {
                return HttpNotFound();
            }
            return View(workexperience);
        }

        // POST: /WorkExperience/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            fillUserData();
            WorkExperience workexperience = await db.WorkExperiences.FindAsync(id);
            db.WorkExperiences.Remove(workexperience);
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
    }
}
