using najjar.biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using najjar.biz.Context;
using System.Web.UI;

namespace najjar.biz.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDataContext db = new ApplicationDataContext();
        [OutputCache(Duration = 604800, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        public ActionResult Index()
        {

            return View();
        }

        [OutputCache(Duration = 604800, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        public ActionResult EmployeeList()
        {
            var employee = from m in db.Employees select m;
            return View(employee.ToList());
        }

        [OutputCache(Duration = 604800, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        public ActionResult Hse()
        {
            return View();
        }

        [OutputCache(Duration = 604800, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        public ActionResult Hse_mngt_sys()
        {
            return View();
        }
        [OutputCache(Duration = 604800, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        public ActionResult Hse_policy()
        {
            return View();
        }
        [OutputCache(Duration = 604800, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        public ActionResult Services()
        {


            return View();
        }
        [OutputCache(Duration = 604800, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        public ActionResult About()
        {

            return View();
        }

        [OutputCache(Duration = 604800, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        public ActionResult WhoWeAre()
        {

            return View();
        }
        [OutputCache(Duration = 604800, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        public ActionResult CompanyGoals()
        {

            return View();
        }

        [OutputCache(Duration = 604800, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        public ActionResult CompanyFutureProspects()
        {

            return View();
        }
        [OutputCache(Duration = 604800, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [OutputCache(Duration = 604800, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        public ActionResult ContactUs()
        {
            return View();
        }

        [OutputCache(Duration = 604800, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        public ActionResult FullWidth1()
        {
            return View();
        }

        public ActionResult oneColumn1()
        {
            return View();
        }

        public ActionResult Services1()
        {
            return View();
        }

        [OutputCache(Duration = 604800, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        public ActionResult cranes()
        {
            return View();
        }

        public ActionResult TwoColumn1()
        {
            return View();
        }
    }
}