using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDACUIA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Ukraine International Airlines (UIA) History";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "You can contact us at: ";

            return View();
        }
    }
}