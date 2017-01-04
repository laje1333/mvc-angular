using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TacdisDeluxeClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
      
                return View();
            
        }

        public void Logout()
        {
            System.Web.HttpContext.Current.Session["Authstuff"] = null;
        }

        public void Login(string auth)
        {
            System.Web.HttpContext.Current.Session["Authstuff"] = auth;
        }

    }
}