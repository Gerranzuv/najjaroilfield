using najjar.biz.Context;
using najjar.biz.Models;
using najjar.biz.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace najjar.biz.Controllers
{
    [Authorize]
    public class OnlineExamController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();
        // GET: OnlineExam
        public ActionResult Index()
        {
            ViewBag.Tests = db.Tests
                .Where(Test => Test.isActive)
                .Select(Test => new { Test.Id, Test.Name })
                .ToList();
            return View();
        }

        public ActionResult InstructionPage(int? TestId, string employee_code)
        {
            Employees selectedEmloyee = db.Employees.FirstOrDefault(emp => emp.EmployeeCode.Equals(employee_code, StringComparison.InvariantCultureIgnoreCase));
            if (selectedEmloyee == null)
            {
                TempData["errMessage"] = "Please Enter A Valid Employee Code!";
                return RedirectToAction("Index");
            }
            else {
                Test selectedTest = db.Tests.Include("TestXQuestions").FirstOrDefault(t => t.Id == TestId);

                if (selectedTest != null)
                {
                    InstructionPageModel instructionPageModel = new InstructionPageModel()
                    {
                        employee = selectedEmloyee,
                        Test = selectedTest
                    };
                    return View(instructionPageModel);
                }
                else
                {
                    TempData["errMessage"] = "Please Select A Valid Test";
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpPost]
        public ActionResult Register(int? TestId, string employee_code)
        {
            // register the user for the Test
            Employees employee = db
                .Employees
                .Include("Registrations")
                .FirstOrDefault(emp => emp.EmployeeCode.Equals(employee_code, StringComparison.InvariantCultureIgnoreCase));

            Test test = db.Tests.FirstOrDefault(t => t.Id == TestId);

            Registration registration = db
                .Registrations
                .FirstOrDefault(reg => reg.TestId == TestId && reg.EmployeeId == employee.Id );

            // If the employee has already registered for the Test --->
            if(registration != null)
            {
                Session["TOKEN"] = registration.Token;
                Session["ExpireDate"] = registration.ExpiresDate;
            }

            // Create New Registration
            else
            {
                Registration newRegistration = new Registration()
                {
                    EmployeeId = employee.Id,
                    TestId = TestId.GetValueOrDefault(),
                    RegistrationDate = DateTime.Now,
                    ExpiresDate = DateTime.Now.AddMinutes(test.DurationInMinutes),
                    Token = Guid.NewGuid()
                };

                employee.Registrations.Add(newRegistration);
                db.Registrations.Add(newRegistration);

                db.SaveChanges();

                Session["TOKEN"] = newRegistration.Token;
                Session["ExpireDate"] = newRegistration.ExpiresDate;
            }

            return RedirectToAction("EvalPage", new { @token = Session["TOKEN"] });
        }

        public ActionResult EvalPage(Guid token, int? qno)
        {
            if(token == null)
            {
                TempData["errMessage"] = "You have an invalid Token. Please Register for the Test again!";
                return RedirectToAction("Index");
            }

            Registration registration = db.Registrations.FirstOrDefault(r => r.Token.Equals(token));

            if(registration.ExpiresDate < DateTime.Now)
            {
                TempData["errMessage"] = "The Test has expired at " + registration.ExpiresDate.ToString();

                db.Registrations.Remove(registration);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            if (qno.GetValueOrDefault() < 1 || qno.GetValueOrDefault() > db.TestXQuestions.Where(x => x.TestId == registration.TestId && x.IsActive).Count())
            {
                qno = 1;
            }

            // Retrieving the current Question --->

            int testXQuestionId = db
                .TestXQuestions
                .Where(x => x.TestId == registration.TestId && x.QuestionNumber == qno)
                .Select(x => x.Id)
                .FirstOrDefault();

            if(testXQuestionId > 0)
            {
                var EvalPageModel = db
                    .TestXQuestions
                    .Include("Test,Question")
                    .Where(x => x.Id == testXQuestionId)
                    .Select(x => new QuestionModel() {
                        TestId = x.TestId,
                        TestName = x.Test.Name,
                        Points = x.Question.points,
                        QuestionType = x.Question.QuestionType,
                        QuestionNumber = x.QuestionNumber,
                        Question = x.Question.QuestionText,
                        TotalQuestionInSet = x.Test.TestXQuestions.Count(txq => txq.IsActive),
                        Options = db
                        .Choices
                        .Where(c => c.IsActive && c.QuestionId == x.QuestionId)
                        .Select(c =>  new QXOModel() {
                               ChoiceId = c.Id,
                               Label = c.Label
                        })
                        .ToList()
                    }).FirstOrDefault();

                    EvalPageModel.DurationInMinutes = registration.ExpiresDate.Subtract(DateTime.Now).Minutes;

                // If the Question is already answered. Set the Choices of the Employee

                var savedAnsweres = db
                    .TestXPapers
                    .Include("Choice")
                    .Where(x => x.TestXQuestionId == testXQuestionId && x.RegistrationId == registration.Id && x.Choice.IsActive)
                    .Select(x => new { x.ChoiceId, x.Answer}).ToList();

                foreach(var savedAnswer in savedAnsweres)
                {
                    EvalPageModel
                        .Options
                        .Where(opt => opt.ChoiceId == savedAnswer.ChoiceId).FirstOrDefault()
                        .Answer = savedAnswer.Answer;
                }

                    return View(EvalPageModel);
            }
            return View("Error");
        }

        [HttpPost]
        public ActionResult PostAnswer(AnswerModel choices)
        {

            Registration registration = db.Registrations.Where(r => r.Token.Equals(choices.Token)).FirstOrDefault();

            if(registration == null)
            {
                TempData["errMessage"] = "You have an invalid Token. Please Register Again for the Test!";
                return RedirectToAction("Index");
            }

            if(registration.ExpiresDate < DateTime.Now) {
                TempData["errMessage"] = "The Test has expired at " + registration.ExpiresDate.ToString();

                db.Registrations.Remove(registration);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            var testQuestionInfo = db
                .TestXQuestions
                .Include("Test,Question")
                .Where(x => x.TestId == registration.TestId && x.QuestionNumber == choices.QuestionId)
                .Select(TQ => new
                {
                    TQID = TQ.Id,
                    QT = TQ.Question.QuestionType,
                    QID = TQ.QuestionId,
                    POINTS = TQ.Question.points
                })
                .FirstOrDefault();

            // Get all the points the Employee has Submitted

            if(testQuestionInfo != null)
            {
                // If the Question of Type Radio or Checkbox
                if(choices.UserSelectedChoices.Count > 1)
                {
                    var AllPointsValuesOfChoices =
                        (from a in db.Choices.Where(c => c.IsActive)
                         join b in choices.UserSelectedId on a.Id equals b
                         select new { a.Id, a.points, a.Label }).AsEnumerable()
                        .Select(x => new TestXPaper()
                        {
                            RegistrationId = registration.Id,
                            ChoiceId = x.Id,
                            TestXQuestionId = testQuestionInfo.TQID,
                            MarkScored = x.points,
                            Answer = x.Label
                        }).ToList();

                    db.TestXPapers.AddRange(AllPointsValuesOfChoices);
                }
                else
                {
                    // If the Question of Type Text Aread --- TODO -----
                }

                db.SaveChanges();
            }

            // Get the Next Question depending on the Direction (forward Or Backward)
            var nextQuestionNumber = 1;

            // Get The Next Question Number from the Database
            nextQuestionNumber = db.TestXQuestions.Where(x => x.TestId == choices.TestId
                && x.QuestionNumber > choices.QuestionId)
                .OrderBy(x => x.QuestionNumber)
                .Take(1)
                .Select(x => x.QuestionNumber)
                .FirstOrDefault();

            if (choices.Direction.Equals("forward", StringComparison.InvariantCultureIgnoreCase))
            {
                // Get The Next Question Number from the Database
                nextQuestionNumber = db.TestXQuestions.Where(x => x.TestId == choices.TestId
                    && x.QuestionNumber > choices.QuestionId)
                    .OrderBy(x => x.QuestionNumber)
                    .Take(1)
                    .Select(x => x.QuestionNumber)
                    .FirstOrDefault();
            }
            else
            {
                // Get The Next Question Number from the Database
                nextQuestionNumber = db.TestXQuestions.Where(x => x.TestId == choices.TestId
                    && x.QuestionNumber < choices.QuestionId)
                    .OrderByDescending(x => x.QuestionNumber)
                    .Take(1)
                    .Select(x => x.QuestionNumber)
                    .FirstOrDefault();
            }

            if(nextQuestionNumber < 1)
            {
                nextQuestionNumber = 1;
            }

            return RedirectToAction("EvalPage", new {
                   @token = Session["TOKEN"],
                   @qno = nextQuestionNumber
            });
        }

        [HttpPost]
        public ActionResult FinalResult(int TestId, Guid token)
        {
            if(token == null)
            {
                TempData["errMessage"] = "Invalid Token. Please Register again for the Test";
                return RedirectToAction("Index");
            }

            Registration registration = db.Registrations.Where(r => r.Token.Equals(token)).FirstOrDefault();

            if(registration == null)
            {
                TempData["errMessage"] = "Invalid Token. Please Register again for the Test";
                return RedirectToAction("Index");
            }

            var textXPapers = db
                .TestXPapers
                .Include("Choice")
                .Include("TestXQuestion")
                .Where(x => x.RegistrationId == registration.Id)
                .ToList();

            return View(textXPapers);
        }
    }
}