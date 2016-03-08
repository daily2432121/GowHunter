using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoWHunter.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Calculator");
        }

        public ActionResult About()
        {
            ViewBag.Message = "GoW Drop Rate Table";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "daily2432121@gmail.com";

            return View();
        }
    }
}