using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using najjar.biz.Models;
using najjar.biz.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace najjar.biz.Controllers
{
    public class ArticleCommentController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();

        // GET: /ArticleComment/
        public ActionResult Index()
        {
            fillUserData();
            return View(db.ArticleComments.ToList());
        }

        // GET: /ArticleComment/Details/5
        public ActionResult Details(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleComment articlecomment = db.ArticleComments.Find(id);
            if (articlecomment == null)
            {
                return HttpNotFound();
            }
            return View(articlecomment);
        }

        // GET: /ArticleComment/Create
        public ActionResult Create()
        {
            fillUserData();
            return View();
        }

        // POST: /ArticleComment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Comment,Date")] ArticleComment articlecomment)
        {
            fillUserData();
            if (ModelState.IsValid)
            {
                db.ArticleComments.Add(articlecomment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articlecomment);
        }

        // GET: /ArticleComment/Edit/5
        public ActionResult Edit(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleComment articlecomment = db.ArticleComments.Find(id);
            if (articlecomment == null)
            {
                return HttpNotFound();
            }
            return View(articlecomment);
        }

        // POST: /ArticleComment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Comment,Date")] ArticleComment articlecomment)
        {
            fillUserData();
            if (ModelState.IsValid)
            {
                db.Entry(articlecomment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(articlecomment);
        }

        // GET: /ArticleComment/Delete/5
        public ActionResult Delete(int? id)
        {
            fillUserData();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArticleComment articlecomment = db.ArticleComments.Find(id);
            if (articlecomment == null)
            {
                return HttpNotFound();
            }
            return View(articlecomment);
        }

        // POST: /ArticleComment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fillUserData();
            ArticleComment articlecomment = db.ArticleComments.Find(id);
            db.ArticleComments.Remove(articlecomment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult addComment(ArticleComment std)
        {

            std.Date = DateTime.Now;
            db.ArticleComments.Add(std);
            db.SaveChanges();
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }


        public JsonResult getComments(int Aarticleid)
        {
            var articlecomments = from s in db.ArticleComments
                                  select s;
            articlecomments = articlecomments.Where(s => s.Articleid.Equals(Aarticleid));

            //List<ArticleComment> comments = new List<ArticleComment>();
            //comments = db.ArticleComments.ToList();

            return Json(articlecomments, JsonRequestBehavior.AllowGet);
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
