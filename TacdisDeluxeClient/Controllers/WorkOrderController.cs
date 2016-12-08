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
        public PartialViewResult WO_Select()
        {
            return PartialView("_WO_Select");
        }

        // GET: WorkOrder
        public PartialViewResult WO_CustData()
        {
            return PartialView("_WO_CustData");
        }

        // GET: WorkOrder
        public PartialViewResult WOJ_Select()
        {
            return PartialView("_WOJ_Select");
        }

        // GET: WorkOrder
        public PartialViewResult WOJ_Manage()
        {
            return PartialView("_WOJ_Manage");
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