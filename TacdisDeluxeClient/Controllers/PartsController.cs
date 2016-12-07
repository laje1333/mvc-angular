using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TacdisDeluxeClient.Controllers
{
    public class PartsController : Controller
    {
        // GET: Parts
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult TempAction()
        {
            return PartialView("_TempAction");
        }
    }
}