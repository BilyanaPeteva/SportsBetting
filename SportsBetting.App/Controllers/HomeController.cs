using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsBetting.App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "SportsBetting is the place where you can find detail information about sport events";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "You can contact us at:";

            return View();
        }
    }
}