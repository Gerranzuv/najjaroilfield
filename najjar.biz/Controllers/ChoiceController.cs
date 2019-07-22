using najjar.biz.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using najjar.biz.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace najjar.biz.Controllers
{
    public class ChoiceController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();

        // GET: Add New Choice
        [HttpGet]
        public ActionResult AddNewChoice(int QuestionId)
        {
            fillUserData();
            Question question = db.Questions.Where(q => q.Id == QuestionId).FirstOrDefault();
            int TestId = db
                .TestXQuestions
                .Where(txq => txq.QuestionId == QuestionId)
                .Select(x => x.TestId)
                .FirstOrDefault();

            if(question != null)
            {
                ViewBag.Question = question;
                ViewBag.TestId = TestId;
                return View();
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult AddNewChoice(Choice choice, int TestId)
        {
            fillUserData();
            if (ModelState.IsValid)
            {
                db.Choices.Add(choice);

                // Saveing to the database
                db.SaveChanges();

                return RedirectToAction("QuestionPage", "Question", new { TestId});
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int ChoiceId, int QuestionId)
        {
            fillUserData();
            Choice choice = db.Choices.Find(ChoiceId);

            if(choice != null)
            {

                int TestId = db
                    .TestXQuestions
                    .Where(txq => txq.QuestionId == QuestionId)
                    .Select(x => x.TestId)
                    .FirstOrDefault();

                ViewBag.Question = db.Questions.Find(QuestionId);
                ViewBag.TestId = TestId;
                return View(choice);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Choice choice, int TestId)
        {
            fillUserData();
            if (ModelState.IsValid)
            {
                Choice choiceToUpdate = db.Choices.Find(choice.Id);
                TryUpdateModel(choiceToUpdate);
                db.Entry(choiceToUpdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("QuestionPage", "Question", new { TestId });
            }
            else
            {
                ViewBag.Question = db.Questions.Find(choice.QuestionId);
                ViewBag.TestId = TestId;
                return View(choice);
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