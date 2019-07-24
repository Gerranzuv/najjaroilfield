using najjar.biz.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using najjar.biz.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Net;

namespace najjar.biz.Controllers
{
    public class ChoiceController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();
        // GET: /Choice/
        public ActionResult Index()
        {
            fillUserData();
            var choices = db.Choices.Include("Question") ;
            return View(choices.ToList());
        }

        // GET: /Choice/Details/5
        public ActionResult Details(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choice choice = db.Choices.Find(id);
            if (choice == null)
            {
                return HttpNotFound();
            }
            return View(choice);
        }

        // GET: /Choice/Create
        public ActionResult Create()
        {
            fillUserData();
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "QuestionType");
            return View();
        }

        // POST: /Choice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,QuestionId,Label,points,IsActive")] Choice choice)
        {
            fillUserData();
            if (ModelState.IsValid)
            {
                db.Choices.Add(choice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "QuestionType", choice.QuestionId);
            return View(choice);
        }

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

            if (question != null)
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

                return RedirectToAction("QuestionPage", "Question", new { TestId });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int ChoiceId, int QuestionId)
        {
            fillUserData();
            Choice choice = db.Choices.Find(ChoiceId);

            if (choice != null)
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

        // GET: /Choice/Delete/5
        public ActionResult Delete(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choice choice = db.Choices.Find(id);
            if (choice == null)
            {
                return HttpNotFound();
            }
            return View(choice);
        }

        // POST: /Choice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fillUserData();
            Choice choice = db.Choices.Find(id);
            db.Choices.Remove(choice);
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