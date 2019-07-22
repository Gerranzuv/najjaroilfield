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
    public class QuestionController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();

        public ActionResult QuestionPage(int TestId)
        {
            fillUserData();
            Test test = db
                .Tests
                .Include("TestXQuestions")
                .Include("TestXQuestions.Question")
                .Include("TestXQuestions.Question.Choices")
                .Where(t => t.Id == TestId)
                .FirstOrDefault();

            if(test != null)
            {
                return View(test);

            }
            else
            {
                return View("Error");
            }
        }
        
        [HttpGet]
        public ActionResult AddNewQuestion(int TestId)
        {
            fillUserData();
            Test test = db.Tests.FirstOrDefault(t => t.Id == TestId);

            if(test != null)
            {
                ViewBag.Categories = new SelectList(db.QuestionCategories.ToList(), "Id", "Category");
                ViewBag.Test = test;

                return View();
            }
            else
            {
                return View("Error");
            }

        }

        [HttpPost]
        public ActionResult AddNewQuestion(Question question, int TestId)
        {
            fillUserData();
            if (ModelState.IsValid)
            {
                string category = db
                    .QuestionCategories
                    .Where(cat => cat.Id == question.CategoryId)
                    .Select(cat => cat.Category)
                    .FirstOrDefault();

                question.QuestionType = category;

                int nextQuestionNumber = db
                        .TestXQuestions
                        .Where(txq => txq.TestId == TestId)
                        .Count() + 1;

                db.Questions.Add(question);
                db.SaveChanges();

                Question lastInsertedQuestion = db
                    .Questions
                    .OrderByDescending(q => q.Id)
                    .FirstOrDefault();

                TestXQuestion testXQuestion = new TestXQuestion()
                {
                    TestId = TestId,
                    QuestionId = lastInsertedQuestion.Id,
                    QuestionNumber = nextQuestionNumber,
                    IsActive = question.IsActive
                };

                db.TestXQuestions.Add(testXQuestion);

                db.SaveChanges();

                return RedirectToAction("QuestionPage", new { TestId });
            }

            // if an Error Occurred!

            Test test = db.Tests.FirstOrDefault(t => t.Id == TestId);

            if (test != null)
            {
                ViewBag.Categories = new SelectList(db.QuestionCategories.ToList(), "Id", "Category");
                ViewBag.Test = test;
            }

            return View(question);
        }
        [HttpGet]
        public ActionResult Edit(int QuestionId, int TestId)
        {
            fillUserData();
            Question question = db.Questions.Find(QuestionId);
            Test test = db.Tests.Where(t => t.Id == TestId).FirstOrDefault();

            if(question != null && test != null)
            {
                ViewBag.Categories = new SelectList(db.QuestionCategories.ToList(), "Id", "Category");
                ViewBag.Test = test;
                return View(question);
            }
            else
            {
                return HttpNotFound("The Question with the Question Id: " + 
                    QuestionId + 
                    " Couldn't be found! Or The Test with TestId: "
                    +TestId+" couldn't be found!");
            }
        }
        [HttpPost]
        public ActionResult Edit(Question question, int TestId)
        {
            fillUserData();
            if (ModelState.IsValid)
            {
                Question questionToUpdate = db
                    .Questions
                    .Where(q => q.Id == question.Id)
                    .FirstOrDefault();
                TryUpdateModel(questionToUpdate);

                questionToUpdate.QuestionType = db
                    .QuestionCategories
                    .Where(cat => cat.Id == question.CategoryId)
                    .Select(cat => cat.Category)
                    .FirstOrDefault();

                db.Entry(questionToUpdate).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("QuestionPage", new { TestId });
            }
            else
            {
                ViewBag.Test = db
                    .Tests
                    .Where(t => t.Id == TestId)
                    .FirstOrDefault();
                return View(question);
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