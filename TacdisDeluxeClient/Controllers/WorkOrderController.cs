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
        public PartialViewResult WOJ_CustData()
        {
            return PartialView("_WOJ_CustData");
        }

        // GET: WorkOrder
        public PartialViewResult WOJob_Kit()
        {
            return PartialView("_WOJob_Kit");
        }

        // GET: WorkOrder
        public PartialViewResult WOJob_Operations()
        {
            return PartialView("_WOJob_Operations");
        }

        // GET: WorkOrder
        public PartialViewResult WOJob_Parts()
        {
            return PartialView("_WOJob_Parts");
        }
    }
}