using System;
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

        // ----------WOH------------
        [System.Web.Http.HttpGet]
        public string GetWoHList(string search)
        {
            using (DBContext c = new DBContext())
            {
                var wohList = WohListData.GetWohList(c.WorkOrder.OrderByDescending(p => p.WoNr));
                return wohList;
            }
        }

        // POST: api/WorkOrder
        [System.Web.Http.HttpPost]
        public void PostWOH(WorkOrderDto wohData)
        {
            WorkOrderEntity wohEnt = new WorkOrderEntity();
            wohEnt.Status = wohData.Status;

            using (DBContext c = new DBContext())
            {
                var tempEnt = c.WorkOrder.OrderByDescending(p => p.WoNr).FirstOrDefault();
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

        // ----------WOJ------------
        [System.Web.Http.HttpGet]
        public string GetWoJobList(string wohid)
        {
            using (DBContext c = new DBContext())
            {
                var wohList = WohListData.GetWojList(c.WorkOrder.Where(p => p.WoNr.ToString() == wohid).Single());
                return wohList;
            }
        }

        // POST: api/WorkOrder
        [System.Web.Http.HttpPost]
        public void PostWOJ(string wohId)
        {
            using (DBContext c = new DBContext())
            {
                var woh = c.WorkOrder.Where(p => p.WoNr.ToString() == wohId).Single();
                woh.WOJ_List.Add(new WoJobEntity());
                c.SaveChanges();
            }
        }

        // ----------WJK------------
        [System.Web.Http.HttpGet]
        public string GetWJKList(string wohId, string wojId)
        {

            using (DBContext c = new DBContext())
            {
                var wjkList = c.WorkOrder.Where(p => p.WoNr.ToString() == wohId).Single()
                    .WOJ_List.Where(p => p.WoJNr.ToString() == wojId).Single().WOJ_KitList;

                return WohListData.GetWjkList(wjkList);
            }
        }

        [System.Web.Http.HttpPost]
        public void AddWJK(string wjkcode, string wohId, string wojId)
        {

            using (DBContext c = new DBContext())
            {
                var wjkList = c.WorkOrder.Where(p => p.WoNr.ToString() == wohId).Single()
                    .WOJ_List.Where(p => p.WoJNr.ToString() == wojId).Single().WOJ_KitList;
                wjkList.Add(new WoKitsEntity(wjkcode));
                c.SaveChanges();
            }
        }

        // ----------WJO------------
        [System.Web.Http.HttpGet]
        public string GetWJOList(string wjocode, string wohId, string wojId)
        {
            using (DBContext c = new DBContext())
            {
                var wjoList = c.WorkOrder.Where(p => p.WoNr.ToString() == wohId).Single()
                    .WOJ_List.Where(p => p.WoJNr.ToString() == wojId).Single().WOJ_OPList;

                return WohListData.GetWjoList(wjoList);
            }
        }

        [System.Web.Http.HttpPost]
        public void AddWJO(string wjocode, string wohId, string wojId)
        {

            using (DBContext c = new DBContext())
            {
                var wjoList = c.WorkOrder.Where(p => p.WoNr.ToString() == wohId).Single()
                    .WOJ_List.Where(p => p.WoJNr.ToString() == wojId).Single().WOJ_OPList;
                wjoList.Add(new WoOpEntitys(wjocode));
                c.SaveChanges();
            }
        }

        // ----------WJP------------
        [System.Web.Http.HttpGet]
        public string GetWJPList(string wjpcode, string wohId, string wojId)
        {
            using (DBContext c = new DBContext())
            {
                var wjpList = c.WorkOrder.Where(p => p.WoNr.ToString() == wohId).Single()
                    .WOJ_List.Where(p => p.WoJNr.ToString() == wojId).Single().WOJ_PartList;

                return WohListData.GetWjpList(wjpList);
            }
        }

        [System.Web.Http.HttpPost]
        public void AddWJP(string wjpcode, string wohId, string wojId)
        {

            using (DBContext c = new DBContext())
            {
                PartEntity part = c.Parts.Where(p => p.ItemId.ToString() == wjpcode).Single();
                ICollection<PartEntity> wjpList = c.WorkOrder.Where(p => p.WoNr.ToString() == wohId).Single()
                    .WOJ_List.Where(p => p.WoJNr.ToString() == wojId).Single().WOJ_PartList;

                wjpList.Add(part);
                c.SaveChanges();
            }
        }

        // ---------RegNr-----------
        [System.Web.Http.Route("GetRegNr")]
        [System.Web.Http.HttpGet]
        public List<string> GetRegNr(string WOHID)
        {
            using (DBContext c = new DBContext())
            {
                List<string> responseArr = new List<string>();
                if (WOHID == null || WOHID == "undefined")
                {
                    responseArr.Add("");
                    return responseArr;
                }
                var WOH = c.WorkOrder.Where(p => p.WoNr.ToString() == WOHID).Single();
                responseArr.Add(WOH.RegNr);
                return responseArr;
            }
        }

        [System.Web.Http.HttpGet]
        public List<string> GetRegNrInfo(string WOHID, string regnr)
        {
            using (DBContext c = new DBContext())
            {
                List<string> responseArr = new List<string>();

                if (!ValidateRegNr(regnr))
                {
                    regnr = "";
                }
                WorkOrderEntity woh = c.WorkOrder.Where(p => p.WoNr.ToString() == WOHID).Single();
                if (woh == null)
                {
                    return responseArr;
                }

                RegNrChanged(woh, regnr.ToUpper());

                responseArr.Add(woh.VehDesc);
                responseArr.Add(woh.VehRegDate.ToString());
                responseArr.Add(woh.VehOwner);
                responseArr.Add(woh.VehDriver);
                responseArr.Add(woh.VehPhoneNr);
                responseArr.Add(woh.VehLastVisDate.ToString());
                responseArr.Add(woh.VehLastVisMil);

                c.SaveChanges();
                return responseArr;
            }
        }

        private void RegNrChanged(WorkOrderEntity woh, string regNr)
        {
            woh.RegNr = regNr;
            woh.VehDesc = GetRegNrDetails.GetVehDesc(regNr);
            woh.VehRegDate = GetRegNrDetails.GetVehRegDate(regNr);
            woh.VehOwner = GetRegNrDetails.GetOwner(regNr);
            woh.VehDriver = GetRegNrDetails.GetDriver(regNr);
            woh.VehPhoneNr = GetRegNrDetails.GetPhoneNr(regNr);
            woh.VehLastVisDate = GetRegNrDetails.GetLastVisDate(regNr);
            woh.VehLastVisMil = GetRegNrDetails.GetLastVisMilage(regNr);
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
