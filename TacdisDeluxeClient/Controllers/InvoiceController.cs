using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TacdisDeluxeClient.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
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
        public PartialViewResult SearchInvoice()
        {
            return PartialView("_SearchInvoice");
        }
    }
}