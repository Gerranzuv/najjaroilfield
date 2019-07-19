using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using najjar.biz.Context;
using najjar.biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (ModelState.IsValid)
            {
                db.Tests.Add(test);
                db.SaveChanges();

                return RedirectToAction("List");
            }

            return View(test);
        }

        [HttpGet]
        public ActionResult Edit(int TestId)
        {
            fillUserData();
            Test testToEdit = db.Tests.Find(TestId);

            if(testToEdit == null)
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

        public void fillUserData()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDataContext()));
            var user = userManager.FindById(User.Identity.GetUserId());
            ViewBag.CurrentUser = user;
        }
    }
}