using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Mvc;
using RestSharp;

namespace GoWHunter.MVC.Controllers
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class CalculatorController : Controller
    {
        // GET: Calculator
        
        public ActionResult Index()
        {
            var result = Backgrounder.Instance.CalculationResult;
            ViewBag.DropTable = result;
            ViewBag.LastUpdated = Backgrounder.LastUpdated.ToString("o");
            return View();
        }
    }
}