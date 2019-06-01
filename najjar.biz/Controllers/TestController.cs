using najjar.biz.Context;
using najjar.biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace najjar.biz.Controllers
{
    public class TestController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();
        // GET: Test
        public ActionResult Index()
        {
            List<Test> tests = db.Tests.Include("TestXQuestions").ToList();
            return View(tests);
        }

        [HttpGet]
        public ActionResult Create()
        {
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
    }
}