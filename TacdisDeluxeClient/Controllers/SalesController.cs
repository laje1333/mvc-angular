using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TacdisDeluxeClient.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            if ((System.Web.HttpContext.Current.Session["Authstuff"] as String) != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
        }
    }
}