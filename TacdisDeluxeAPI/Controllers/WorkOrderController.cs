using AutoMapper;
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
        // ----------WOH------------
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetWoHList")]
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
        public WorkOrderDto GetWoh(string wohid)
        {
            using (DBContext c = new DBContext())
            {
                var woh = GetWoh(wohid, c);
                WorkOrderDto woDto = Mapper.Map<WorkOrderEntity, WorkOrderDto>(woh);   //new WorkOrderDto(woh);

                return woDto;
            }
        }

        private WorkOrderEntity GetWoh(string wohid, DBContext dbc)
        {
            try
            {
                var woh = dbc.WorkOrder.Where(p => p.WoNr.ToString() == wohid).Single();
                return woh;
            }
            catch (Exception)
            {
                return new WorkOrderEntity();
            }
        }

        // POST: api/WorkOrder
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("PostWOH")]
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
        public VehicleServiceDto GetRegNrInfo(string WOHID, string regnr)
        {
            using (DBContext c = new DBContext())
            {
                VehicleServiceDto vehServDto = new VehicleServiceDto();
                if (!ValidateRegNr(regnr))
                {
                    regnr = "";
                }
                WorkOrderEntity woh;
                VehicleEntity veh;
                try
                {
                    woh = GetWoh(WOHID, c);
                    veh = c.Vehicles.Single(p => p.RegNo == regnr);
                }
                catch (Exception)
                {
                    return vehServDto;
                }
                if (woh == null)
                {
                    return vehServDto;
                }

                if (woh.RegNr != regnr)
                {
                    RegNrChanged(woh, veh);
                }

                vehServDto.VehDesc = woh.VehDesc;
                vehServDto.VehRegDate = woh.VehRegDate;
                vehServDto.VehOwner = woh.VehOwner;
                vehServDto.VehDriver = woh.VehDriver;
                vehServDto.VehPhoneNr = woh.VehPhoneNr;
                vehServDto.VehLastVisDate = woh.VehLastVisDate;
                vehServDto.VehLastVisMil = woh.VehLastVisMil;

                c.SaveChanges();
                return vehServDto;
            }
        }

        private void RegNrChanged(WorkOrderEntity woh, VehicleEntity veh)
        {
            woh.RegNr = veh.RegNo;
            woh.VehDesc = veh.ItemName;
            woh.VehRegDate = veh.RegistrationDate;
            woh.VehOwner = veh.Owner.FirstName + " " + veh.Owner.LastName;
            woh.VehDriver = veh.Owner.FirstName + " " + veh.Owner.LastName;
            woh.VehPhoneNr = veh.Owner.PhoneNr;
            woh.VehLastVisDate = veh.LastServiceDate;
            woh.VehLastVisMil = veh.Milage.ToString();
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("PostCarData")]
        public void PostCarData(VehicleServiceDto serviceData)
        {
            using (DBContext c = new DBContext())
            {
                var woh = GetWoh(serviceData.wohId, c);

                woh.VehDesc = serviceData.VehDesc;
                woh.VehRegDate = serviceData.VehRegDate;
                woh.VehOwner = serviceData.VehOwner;
                woh.VehDriver = serviceData.VehDriver;
                woh.VehPhoneNr = serviceData.VehPhoneNr;
                woh.VehLastVisDate = serviceData.VehLastVisDate;
                woh.VehLastVisMil = serviceData.VehLastVisMil;

                c.SaveChanges();
            }
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
        public void PostStatusData(WoStatusDto statusData)
        {
            using (DBContext c = new DBContext())
            {
                var woh = GetWoh(statusData.wohId, c);
                woh.PlannedDate = statusData.plannedDate;
                woh.isCheckedIn = statusData.isCheckedIn;
                woh.CheckedInDate = statusData.checkedInDate;
                woh.CurrentMilage = statusData.currentMilage;
                woh.PlannedMechID = statusData.plannedMechID;
                woh.RespBy = Mapper.Map<SalesmanDto, SalesmanEntity>(statusData.salesman);
                woh.MainPayer = Mapper.Map<PayerDto, PayerEntity>(statusData.payer);

                c.Payers.Attach(woh.MainPayer);
                c.Salesmen.Attach(woh.RespBy);

                c.SaveChanges();
            }
        }

        // --------Finalize---------

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("Picklist")]
        public void Picklist(string wohId)
        {
            using (DBContext c = new DBContext())
            {
                var woh = GetWoh(wohId, c);
                woh.UpdateTotCost();
                var partList = new List<PartEntity>();
                foreach (var woj in woh.WOJ_List)
                {
                    foreach (var part in woj.WOJ_PartList)
                    {
                        partList.Add(part);
                    }

                    foreach (var kit in woj.WOJ_KitList)
                    {
                        foreach (var part in kit.WOJ_PartList)
                        {
                            partList.Add(part);
                        }
                    }
                }

                foreach (var part in partList)
                {
                    //check if parts is available in storage
                }

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
                var woj = new WoJobEntity();
                if (woh.WOJ_List.Count > 0)
                {
                    woj.WoJNr = woh.WOJ_List.OrderByDescending(p => p.WoJNr).FirstOrDefault().WoJNr + 1;
                }
                else
                {
                    woj.WoJNr = 0;
                }
                woh.WOJ_List.Add(woj);
                c.SaveChanges();
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("RemoveWOJ")]
        public void RemoveWOJ(string wohId, string wojId)
        {
            using (DBContext c = new DBContext())
            {
                var woj = GetWoJ(wohId, wojId, c);
                c.WorkOrderJobs.Remove(woj);
                c.SaveChanges();
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetWoJ")]
        public WoJobDto GetWoJ(string wohid, string wojid)
        {
            using (DBContext c = new DBContext())
            {
                var woj = GetWoJ(wohid, wojid, c);
                WoJobDto woDto = Mapper.Map<WoJobEntity, WoJobDto>(woj);

                return woDto;
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("PostWoJData")]
        public void PostWoJData(WoJobDtoExtended statusData)
        {
            using (DBContext c = new DBContext())
            {
                var woj = GetWoJ(statusData.wohid, statusData.wojid, c);

                woj.Status = statusData.Status;
                woj.JobDoneDate = statusData.JobDoneDate;

                woj.PayerCustNr = statusData.PayerCustNr;
                woj.Alias = statusData.Alias;
                woj.AddressType = statusData.AddressType;
                woj.AddressFull = statusData.AddressFull;
                woj.PayerName = statusData.PayerName;
                woj.FirstName = statusData.FirstName;
                woj.Contact = statusData.Contact;
                woj.PaymentMethod = statusData.PaymentMethod;

                woj.FixedPrice = statusData.FixedPrice;
                woj.VatPerc = statusData.VatPerc;

                woj.RefNo = statusData.RefNo;
                woj.RefNoExtra = statusData.RefNoExtra;
                woj.ProfCentreID = statusData.ProfCentreID;
                woj.ProfCentreName = statusData.ProfCentreName;

                c.SaveChanges();
            }
        }

        private WoJobEntity GetWoJ(string wohid, string wojid, DBContext c)
        {
            try
            {
                return GetWoh(wohid, c).WOJ_List.Where(p => p.WoJNr.ToString() == wojid).Single();
            }
            catch (Exception)
            {
                return new WoJobEntity();
            }
        }

        // ----------WJK------------
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetWJKList")]
        public string GetWJKList(string wohId, string wojId)
        {
            using (DBContext c = new DBContext())
            {
                var wjkList = GetWoJ(wohId, wojId, c).WOJ_KitList;

                return WohListData.GetWjkList(wjkList);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("AddWJK")]
        public void AddWJK(string wohId, string wojId, string wjkCode)
        {

            using (DBContext c = new DBContext())
            {
                var wjkList = GetWoJ(wohId, wojId, c).WOJ_KitList;
                wjkList.Add(new WoKitsEntity(wjkCode));
                c.SaveChanges();
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("RemoveWJK")]
        public void RemoveWJK(string wohId, string wojId, string wjkId)
        {
            using (DBContext c = new DBContext())
            {
                var woj = GetWoJ(wohId, wojId, c);
                var item = woj.WOJ_KitList.Where(p => p.Id.ToString() == wjkId).Single();
                c.WorkOrderKits.Remove(item);
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
                var wjoList = GetWoJ(wohId, wojId, c).WOJ_OPList;

                return WohListData.GetWjoList(wjoList);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("AddWJO")]
        public void AddWJO(string wohId, string wojId, string wjoCode)
        {

            using (DBContext c = new DBContext())
            {
                var wjoList = GetWoJ(wohId, wojId, c).WOJ_OPList;
                wjoList.Add(new WoOpEntitys(wjoCode));
                c.SaveChanges();
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("RemoveWJO")]
        public void RemoveWJO(string wohId, string wojId, string wjoId)
        {
            using (DBContext c = new DBContext())
            {
                var woj = GetWoJ(wohId, wojId, c);
                var item = woj.WOJ_OPList.Where(p => p.Id.ToString() == wjoId).Single();
                c.WorkOrderOperations.Remove(item);
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
                var woj = GetWoJ(wohId, wojId, c);

                return WohListData.GetWjpList(woj);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("AddWJP")]
        public void AddWJP(string wohId, string wojId, string wjpCode, string quantity)
        {
            using (DBContext c = new DBContext())
            {
                PartEntity part = c.Parts.Where(p => p.ItemId.ToString() == wjpCode).Single();
                var woj = GetWoJ(wohId, wojId, c);
                woj.WOJ_PartList.Add(part);

                IdAndAmountEntity exist = null;
                foreach (var item in woj.WOJ_PartList_Ids)
                {
                    if (item.Id == part.ItemId)
                    {
                        exist = item;
                        break;
                    }
                }
                if (exist == null)
                {
                    woj.WOJ_PartList_Ids.Add(new IdAndAmountEntity(part.Id, double.Parse(quantity)));
                }
                else
                {
                    exist.Amount += double.Parse(quantity);
                }

                c.SaveChanges();
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("RemoveWJP")]
        public void RemoveWJP(string wohId, string wojId, string wjpId)
        {
            using (DBContext c = new DBContext())
            {
                var woj = GetWoJ(wohId, wojId, c);
                var item = woj.WOJ_PartList.Where(p => p.Id.ToString() == wjpId).Single();
                woj.WOJ_PartList.Remove(item);
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
