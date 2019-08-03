using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using najjar.biz.Context;
using najjar.biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace najjar.biz.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();
        // GET: Test
        public ActionResult Index()
        {
            fillUserData();
            List<Test> tests = db.Tests.Include("TestXQuestions").ToList();
            return View(tests);
        }

        [HttpGet]
        public ActionResult Create()
        {
            fillUserData();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Test test)
        {
            fillUserData();
            if (ModelState.IsValid)
            {
                db.Tests.Add(test);
                db.SaveChanges();

                return RedirectToAction("index");
            }

            return View(test);
        }

        [HttpGet]
        public ActionResult Edit(int TestId)
        {
            fillUserData();
            Test testToEdit = db.Tests.Find(TestId);

            if (testToEdit == null)
            {
                return HttpNotFound("The Test with the Test Id: " + TestId + " Couldn't be found!");
            }
            else
            {
                return View(testToEdit);
            }
        }

        [HttpPost]
        public ActionResult Edit(Test test)
        {
            fillUserData();
            if (ModelState.IsValid)
            {

                Test testToUpdate = db.Tests.Find(test.Id);
                TryUpdateModel(testToUpdate);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(test);
            }
        }

        // GET: /Test/Delete/5
        public ActionResult Delete(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = db.Tests.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: /Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fillUserData();
            Test test = db.Tests.Find(id);
            List<TestXQuestion> questions = new List<TestXQuestion>();
            if(test.TestXQuestions!=null)
             questions = test.TestXQuestions.ToList();

            if (questions.ToList().Count > 0) {
                foreach (var item in questions)
                {
                    var choices = item.TestXPapers;
                    if (choices.ToList().Count > 0)
                        db.TestXPapers.RemoveRange(choices);
                    db.TestXQuestions.Remove(item);
                }
            }
            
            List<Registration> registrations = db.Registrations.Where(s => s.TestId.Equals(id)).ToList();

            foreach (var item in registrations)
            {
                db.Registrations.Remove(item);
            }

            db.Tests.Remove(test);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void fillUserData()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDataContext()));
            var user = userManager.FindById(User.Identity.GetUserId());
            ViewBag.CurrentUser = user;
        }

        
    }
}