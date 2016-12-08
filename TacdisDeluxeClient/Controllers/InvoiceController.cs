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
            return View();
        }
        public PartialViewResult SearchInvoice()
        {
            return PartialView("_SearchInvoice");
        }
    }
}