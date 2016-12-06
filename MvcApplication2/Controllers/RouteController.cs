using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class RouteController : Controller
    {
        public ActionResult One(int stuff = 1)
        {
            ViewBag.Stuff = stuff;
            return View();
        }

        public ActionResult Two()
        {
            return View();
        }

        public ActionResult Three()
        {
            return View();
        }

        public ActionResult Four()
        {
            return View();
        }
    }
}
