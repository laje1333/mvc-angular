﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using TacdisDeluxeAPI.DTO;
using TacdisDeluxeAPI.Mockdata.WorkOrderData;
using TacdisDeluxeAPI.Models;

namespace TacdisDeluxeAPI.Controllers
{
    [System.Web.Http.RoutePrefix("api/workorder")]
    public class WorkOrderController : ApiController
    {
        static string CurrentWOHID;
        static string CurrentWOJID;

        [System.Web.Http.HttpGet]
        public List<string> GetNewWO(string addNew, string wohId)
        {
            List<string> responseArr = new List<string>();
            switch (addNew)
            {
                case "WOH":
                    var WoEntity = new WorkOrderEntity();

                    using (DBContext c = new DBContext())
                    {
                        c.WorkOrder.Add(WoEntity);
                    }

                    wohId = WorkOrderDB.CreateNewWorkOrder();
                    CurrentWOHID = wohId;
                    CurrentWOJID = "";
                    responseArr.Add(wohId);
                    break;
                case "WOJ":
                    var wohJobId = WorkOrderDB.GetWorkOrder(wohId).CreateNewWorkOrderJob();
                    CurrentWOJID = wohJobId;
                    responseArr.Add(wohJobId);
                    break;
                default:
                    break;
            }

            return responseArr;
        }

        [System.Web.Http.HttpGet]
        public List<string> GetCurrentWO(string getCurrent)
        {
            List<string> responseArr = new List<string>();
            switch (getCurrent)
            {
                case "WOH":
                    responseArr.Add(CurrentWOHID);
                    break;
                case "WOJ":
                    responseArr.Add(CurrentWOJID);
                    break;
                default:
                    break;
            }

            return responseArr;
        }

        [System.Web.Http.HttpGet]
        public List<string> SetCurrentWO(string setCurrent, string itemId)
        {
            List<string> responseArr = new List<string>();
            switch (setCurrent)
            {
                case "WOH":
                    CurrentWOHID = itemId;
                    responseArr.Add(CurrentWOHID);
                    break;
                case "WOJ":
                    CurrentWOJID = itemId;
                    responseArr.Add(CurrentWOJID);
                    break;
                default:
                    break;
            }

            return responseArr;
        }

        [System.Web.Http.HttpGet]
        public string GetWoHList(string search)
        {
            var wohList = WohListData.GetWohList(search);

            return wohList;
        }

        [System.Web.Http.Route("GetWoJobList")]
        [System.Web.Http.HttpGet]
        public string GetWoJobList(string wohid)
        {
            var wohList = WohListData.GetWojList(wohid);

            return wohList;
        }

        [System.Web.Http.HttpGet]
        public string GetWJKList(string wjkcode, string wohId, string wojId)
        {
            WorkOrderDB.GetWorkOrder(wohId).GetWoJList(wojId).AddNewWJK(wjkcode);
            var wohList = WohListData.GetWjkList(wohId, wojId);
            return wohList;
        }

        [System.Web.Http.HttpGet]
        public string GetWJOList(string wjocode, string wohId, string wojId)
        {
            WorkOrderDB.GetWorkOrder(wohId).GetWoJList(wojId).AddNewWJO(wjocode);
            var wohList = WohListData.GetWjoList(wohId, wojId);
            return wohList;
        }

        [System.Web.Http.HttpGet]
        public string GetWJPList(string wjpcode, string wohId, string wojId)
        {
            WorkOrderDB.GetWorkOrder(wohId).GetWoJList(wojId).AddNewWJP(wjpcode);
            var wohList = WohListData.GetWjpList(wohId, wojId);
            return wohList;
        }

        [System.Web.Http.Route("GetRegNr")]
        [System.Web.Http.HttpGet]
        public List<string> GetRegNr(string WOHID)
        {
            List<string> responseArr = new List<string>();
            if (WOHID == null || WOHID == "undefined")
            {
                responseArr.Add("");
                return responseArr;
            }
            responseArr.Add(WorkOrderDB.GetWorkOrder(WOHID).RegNr);
            return responseArr;
        }

        [System.Web.Http.HttpGet]
        public List<string> GetRegNrInfo(string WOHID, string regnr)
        {
            List<string> responseArr = new List<string>();

            if (!ValidateRegNr(regnr))
            {
                regnr = "";
            }
            var woh = WorkOrderDB.GetWorkOrder(WOHID);
            if (woh == null)
            {
                return responseArr;
            }

            woh.RegNrChanged(regnr.ToUpper());

            responseArr.Add(woh.VehDesc);
            responseArr.Add(woh.VehRegDate);
            responseArr.Add(woh.VehOwner);
            responseArr.Add(woh.VehDriver);
            responseArr.Add(woh.VehPhoneNr);
            responseArr.Add(woh.VehLastVisDate);
            responseArr.Add(woh.VehLastVisMil);

            return responseArr;

        }

        private bool ValidateRegNr(string regnr)
        {
            if (regnr == null || regnr == "undefined")
            {
                return false;
            }
            Regex regex = new Regex("[0-9]{6,7}|[a-zA-Z]{1,3}[0-9]{1,6}");

            if (!regex.IsMatch(regnr))
            {
                return false;
            }
            return true;
        }

        [System.Web.Http.HttpGet]
        public string Get(string stuff)
        {

            return stuff + "stuff";

        }


        // POST: api/WorkOrder
        [System.Web.Http.HttpPost]
        public void PostWOH(WorkOrderDto wohData)
        {
            WorkOrderEntity wohEnt = new WorkOrderEntity();
            wohEnt.Status = wohData.Status;

            using (DBContext c = new DBContext())
            {
                var tempEnt = c.WorkOrder.FirstOrDefault();
                if (tempEnt == null)
                {
                    wohEnt.WoNr = 120000;
                }
                else
                {
                    wohEnt.WoNr = tempEnt.WoNr + 1;
                }
                wohEnt.CreatedDate = DateTime.Now;
                c.WorkOrder.Add(wohEnt);
                c.SaveChanges();
            }
        }

        // PUT: api/WorkOrder/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/WorkOrder/5
        public void Delete(int id)
        {
        }
    }
}
