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
    public class ServicesController : Controller
    {



        [OutputCache(Duration = 604800, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        public ActionResult WireLineLogging()
        {
            return View();
        }

        [OutputCache(Duration = 604800, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        public ActionResult HsePage()
        {
            return View();
        }

        [OutputCache(Duration = 604800, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        public ActionResult Sickline()
        {
            return View();
        }

        [OutputCache(Duration = 604800, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        public ActionResult SurfaceWellTesting()
        {
            return View();
        }


        [OutputCache(Duration = 604800, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        public ActionResult CoiledTubingAndFrac()
        {
            return View();
        }
        [OutputCache(Duration = 604800, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        public ActionResult OilphaseLab()
        {
            return View();
        }
        [OutputCache(Duration = 604800, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        public ActionResult Cementing()
        {
            return View();
        }
        [OutputCache(Duration = 604800, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        public ActionResult ServicesPage()
        {
            return View();
        }

        [OutputCache(Duration = 604800, VaryByParam = "None", Location = OutputCacheLocation.ServerAndClient, NoStore = false)]
        public ActionResult Quantec()
        {
            return View();
        }
    }
}