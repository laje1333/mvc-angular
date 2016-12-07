using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TacdisDeluxeClient.Controllers
{
    public class WorkOrderController : Controller
    {
        // GET: WorkOrder
        public ActionResult Index()
        {
            return View();
        }

        // GET: WorkOrder
        public PartialViewResult WOJCustData()
        {
            return PartialView();
        }

        // GET: WorkOrder
        public PartialViewResult WOJob_Kit()
        {
            return PartialView();
        }

        // GET: WorkOrder
        public PartialViewResult WOJob_Operations()
        {
            return PartialView();
        }

        // GET: WorkOrder
        public PartialViewResult WOJob_Parts()
        {
            return PartialView();
        }
    }
}