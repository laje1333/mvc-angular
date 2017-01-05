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
        // ----------WOH------------
        [System.Web.Http.HttpGet]
        public string GetWoHList(string search)
        {
            using (DBContext c = new DBContext())
            {
                IOrderedQueryable<Models.WorkOrderEntity> woEntList;
                if (search != null && search != "" && search != "undefined")
                {
                    woEntList = c.WorkOrder.Where(s => s.WoNr.ToString().Contains(search) || 
                        s.RegNr.ToString().Contains(search) ||
                        s.Status.ToString().Contains(search) ||
                        s.VehDesc.ToString().Contains(search) ||
                        s.CreatedDate.ToString().Contains(search) ||
                        s.MainPayer.ToString().Contains(search) ||
                        s.RespBy.ToString().Contains(search) ||
                        s.TotCost.ToString().Contains(search))
                        .OrderByDescending(p => p.WoNr);
                }
                else
                {
                    woEntList = c.WorkOrder.OrderByDescending(p => p.WoNr);
                }
                var wohList = WohListData.GetWohList(woEntList);
                return wohList;
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetWoh")]
        public WorkOrderEntity GetWoh(string wohid)
        {
            using (DBContext c = new DBContext())
            {
                return GetWoh(wohid, c);
            }
        }

        private WorkOrderEntity GetWoh(string wohid, DBContext dbc)
        {
            var woh = dbc.WorkOrder.Where(p => p.WoNr.ToString() == wohid).Single();
            return woh;
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

        // ---------RegNr-----------
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetRegNr")]
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
                var WOH = GetWoh(WOHID, c);
                responseArr.Add(WOH.RegNr);
                return responseArr;
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetRegNrInfo")]
        public List<object> GetRegNrInfo(string WOHID, string regnr)
        {
            using (DBContext c = new DBContext())
            {
                List<object> responseArr = new List<object>();
                if (!ValidateRegNr(regnr))
                {
                    regnr = "";
                }
                WorkOrderEntity woh;
                try
                {
                    woh = GetWoh(WOHID, c);
                }
                catch (Exception)
                {
                    return responseArr;
                }
                if (woh == null)
                {
                    return responseArr;
                }

                RegNrChanged(woh, regnr.ToUpper());

                responseArr.Add(woh.VehDesc);
                responseArr.Add(woh.VehRegDate);
                responseArr.Add(woh.VehOwner);
                responseArr.Add(woh.VehDriver);
                responseArr.Add(woh.VehPhoneNr);
                responseArr.Add(woh.VehLastVisDate);
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

        // ---------Status----------
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("PostStatusData")]
        public void PostStatusData(WoStatusDto wohstatus)
        {
            using (DBContext c = new DBContext())
            {
                var woh = GetWoh(wohstatus.wohId, c);
                woh.PlannedDate = wohstatus.plannedDate;
                woh.isCheckedIn = wohstatus.isCheckedIn;
                woh.CheckedInDate = wohstatus.checkedInDate;
                woh.CurrentMilage = wohstatus.currentMilage;
                woh.PlannedMechID = wohstatus.plannedMechID;
                
                c.SaveChanges();
            }
        }

        // ----------WOJ------------
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetWoJobList")]
        public string GetWoJobList(string wohid)
        {
            using (DBContext c = new DBContext())
            {
                var wohList = WohListData.GetWojList(GetWoh(wohid, c));
                return wohList;
            }
        }
        
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("PostWOJ")]
        public void PostWOJ(string wohId)
        {
            using (DBContext c = new DBContext())
            {
                var woh = GetWoh(wohId, c);
                woh.WOJ_List.Add(new WoJobEntity());
                c.SaveChanges();
            }
        }

        // ----------WJK------------
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetWJKList")]
        public string GetWJKList(string wohId, string wojId)
        {

            using (DBContext c = new DBContext())
            {
                var wjkList = GetWoh(wohId, c).WOJ_List.Where(p => p.WoJNr.ToString() == wojId).Single().WOJ_KitList;

                return WohListData.GetWjkList(wjkList);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("AddWJK")]
        public void AddWJK(string wjkcode, string wohId, string wojId)
        {

            using (DBContext c = new DBContext())
            {
                var wjkList = GetWoh(wohId, c).WOJ_List.Where(p => p.WoJNr.ToString() == wojId).Single().WOJ_KitList;
                wjkList.Add(new WoKitsEntity(wjkcode));
                c.SaveChanges();
            }
        }

        // ----------WJO------------
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetWJOList")]
        public string GetWJOList(string wohId, string wojId)
        {
            using (DBContext c = new DBContext())
            {
                var wjoList = GetWoh(wohId, c).WOJ_List.Where(p => p.WoJNr.ToString() == wojId).Single().WOJ_OPList;

                return WohListData.GetWjoList(wjoList);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("AddWJO")]
        public void AddWJO(string wjocode, string wohId, string wojId)
        {

            using (DBContext c = new DBContext())
            {
                var wjoList = GetWoh(wohId, c).WOJ_List.Where(p => p.WoJNr.ToString() == wojId).Single().WOJ_OPList;
                wjoList.Add(new WoOpEntitys(wjocode));
                c.SaveChanges();
            }
        }

        // ----------WJP------------
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetWJPList")]
        public string GetWJPList(string wohId, string wojId)
        {
            using (DBContext c = new DBContext())
            {
                var wjpList = GetWoh(wohId, c).WOJ_List.Where(p => p.WoJNr.ToString() == wojId).Single().WOJ_PartList;

                return WohListData.GetWjpList(wjpList);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("AddWJP")]
        public void AddWJP(string wjpcode, string wohId, string wojId)
        {

            using (DBContext c = new DBContext())
            {
                PartEntity part = c.Parts.Where(p => p.ItemId.ToString() == wjpcode).Single();
                ICollection<PartEntity> wjpList = GetWoh(wohId, c).WOJ_List.Where(p => p.WoJNr.ToString() == wojId).Single().WOJ_PartList;

                wjpList.Add(part);
                c.SaveChanges();
            }
        }


        // ---------Ignore----------
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
