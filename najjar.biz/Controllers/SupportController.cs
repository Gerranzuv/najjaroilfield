using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using najjar.biz.Models;
using najjar.biz.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MultipleFileUpload.Controllers
{
    public class SupportController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();

        //
        // GET: /Support/

        public ActionResult Index()
        {
            fillUserData();
            return View(db.Supports.ToList());
        }

        //
        // GET: /Support/Create

        public ActionResult Create()
        {
            fillUserData();
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Support support)
        {
            fillUserData();
            if (ModelState.IsValid)
            {
                List<FileDetail> fileDetails = new List<FileDetail>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileDetail fileDetail = new FileDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid()
                        };
                        fileDetails.Add(fileDetail);

                        var path = Path.Combine(Server.MapPath("~/Images/"), fileDetail.Id + fileDetail.Extension);
                        file.SaveAs(path);
                    }
                }

                support.FileDetails = fileDetails;
                Employees emp = db.Employees.Find(support.EmpId);
                support.employee = emp;
             //   support.FileId = (Int32)fileDetails[0].Id;
                
                db.Supports.Add(support);
                db.SaveChanges();
                return RedirectToAction("EmployeeDocs", new { Employeeid =emp.Id});
            }

            return View(support);
        }

        //
        // GET: /Support/Edit/5

        public ActionResult Edit(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Support support = db.Supports.Include(s => s.FileDetails).SingleOrDefault(x => x.SupportId == id);
            
            if (support == null)
            {
                return HttpNotFound();
            }
            return View(support);
        }


        public FileResult Download(String p, String d)
        {
            fillUserData();
            return File(Path.Combine(Server.MapPath("~/Images/"), p), System.Net.Mime.MediaTypeNames.Application.Octet, d);
        }



        //
        // POST: /Support/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Support support)
        {
            fillUserData();
            if (ModelState.IsValid)
            {

                //New Files
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        FileDetail fileDetail = new FileDetail()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid(),
                            SupportId = support.SupportId
                        };
                        var path = Path.Combine(Server.MapPath("~/Images/"), fileDetail.Id + fileDetail.Extension);
                        file.SaveAs(path);

                        db.Entry(fileDetail).State = EntityState.Added;
                    }
                }

                db.Entry(support).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EmployeeDocs", new { Employeeid = support.EmpId });
            }
            return View(support);
        }




        [HttpPost]
        public JsonResult DeleteFile(string id)
        {
            fillUserData();
            if (String.IsNullOrEmpty(id))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }
            try
            {
                Guid guid = new Guid(id);
                FileDetail fileDetail = db.FileDetails.Find(guid);
                if (fileDetail == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //Remove from database
                db.FileDetails.Remove(fileDetail);
                db.SaveChanges();

                //Delete file from the file system
                var path = Path.Combine(Server.MapPath("~/Images/"), fileDetail.Id + fileDetail.Extension);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }





        //
        // POST: /Support/Delete/5

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                Support support = db.Supports.Find(id);
                if (support == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                //delete files from the file system

                foreach (var item in support.FileDetails)
                {
                    String path = Path.Combine(Server.MapPath("~/Images/"), item.Id + item.Extension);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }

                db.Supports.Remove(support);
                db.SaveChanges();
                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }


        // Post: /Support/EmployeeDocs/5
        public ActionResult EmployeeDocs(int Employeeid)
        {
            fillUserData();
            if (Employeeid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            return View(db.Supports.Where(x => x.EmpId == Employeeid).ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
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