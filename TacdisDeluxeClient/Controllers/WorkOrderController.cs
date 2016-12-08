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
        public PartialViewResult WOH_Select()
        {
            return PartialView("_WOH_Select");
        }

        // GET: WorkOrder
        public PartialViewResult WOH_CustData()
        {
            return PartialView("_WOH_CustData");
        }

        // GET: WorkOrder
        public PartialViewResult WOH_Manage()
        {
            return PartialView("_WOH_Manage");
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
        public PartialViewResult WOJ_Kit()
        {
            return PartialView("_WOJ_Kit");
        }

        // GET: WorkOrder
        public PartialViewResult WOJ_Operations()
        {
            return PartialView("_WOJ_Operations");
        }

        // GET: WorkOrder
        public PartialViewResult WOJ_Parts()
        {
            return PartialView("_WOJ_Parts");
        }
    }
}