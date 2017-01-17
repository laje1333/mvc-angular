using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Http;
using TacdisDeluxeAPI.DTO;
using TacdisDeluxeAPI.Mockdata.WorkOrderData;
using TacdisDeluxeAPI.Models;

namespace TacdisDeluxeAPI.Controllers
{
    [RoutePrefix("api/workorder")]
    public class WorkOrderController : ApiController
    {
        // ----------WOH------------
        [HttpGet]
        [Route("GetWoHList")]
        public string GetWoHList(string search)
        {
            using (var c = new DBContext())
            {
                IOrderedQueryable<WorkOrderEntity> woEntList;
                if (!string.IsNullOrEmpty(search) && search != "undefined")
                {
                    woEntList = c.WorkOrder.Where(s => s.WoNr.ToString().Contains(search) ||
                        s.RegNr.Contains(search) ||
                        s.Status.Contains(search) ||
                        s.VehDesc.Contains(search) ||
                        s.CreatedDate.ToString().Contains(search) ||
                        s.MainPayer.FirstName.Contains(search) ||
                        s.MainPayer.LastName.Contains(search) ||
                        s.RespBy.FirstName.Contains(search) ||
                        s.RespBy.LastName.Contains(search) ||
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

        [HttpGet]
        [Route("GetWoh")]
        public WorkOrderDto GetWoh(string wohid)
        {
            using (var c = new DBContext())
            {
                var woh = GetWoh(wohid, c);
                var woDto = Mapper.Map<WorkOrderEntity, WorkOrderDto>(woh);   //new WorkOrderDto(woh);

                return woDto;
            }
        }

        private WorkOrderEntity GetWoh(string wohid, DBContext dbc)
        {
            try
            {
                var woh = dbc.WorkOrder.Single(p => p.WoNr.ToString() == wohid);
                return woh;
            }
            catch (Exception)
            {
                return new WorkOrderEntity();
            }
        }

        // POST: api/WorkOrder
        [HttpPost]
        [Route("PostWoh")]
        public void PostWoh(WorkOrderDto wohData)
        {
            var wohEnt = new WorkOrderEntity {Status = wohData.Status};

            using (var c = new DBContext())
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
        [HttpGet]
        [Route("GetRegNr")]
        public List<string> GetRegNr(string wohId)
        {
            using (var c = new DBContext())
            {
                var responseArr = new List<string>();
                if (wohId == null || wohId == "undefined")
                {
                    responseArr.Add("");
                    return responseArr;
                }
                var woh = GetWoh(wohId, c);
                responseArr.Add(woh.RegNr);
                return responseArr;
            }
        }

        [HttpGet]
        [Route("GetRegNrInfo")]
        public VehicleServiceDto GetRegNrInfo(string wohId, string regnr)
        {
            using (var c = new DBContext())
            {
                var vehServDto = new VehicleServiceDto();
                if (!ValidateRegNr(regnr))
                {
                    regnr = "";
                }
                WorkOrderEntity woh;
                VehicleEntity veh;
                try
                {
                    woh = GetWoh(wohId, c);
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

        [HttpPost]
        [Route("PostCarData")]
        public void PostCarData(VehicleServiceDto serviceData)
        {
            using (var c = new DBContext())
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

        private static bool ValidateRegNr(string regnr)
        {
            if (regnr == null || regnr == "undefined")
            {
                return false;
            }
            var regex = new Regex("[0-9]{6,7}|[a-zA-Z]{1,3}[0-9]{1,6}");

            if (!regex.IsMatch(regnr))
            {
                return false;
            }
            return true;
        }

        // ---------Status----------
        [HttpPost]
        [Route("PostStatusData")]
        public void PostStatusData(WoStatusDto statusData)
        {
            using (var c = new DBContext())
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

        [HttpPost]
        [Route("Picklist")]
        public void Picklist(string wohId)
        {
            using (var c = new DBContext())
            {
                var woh = GetWoh(wohId, c);
                woh.UpdateTotCost();
                var partList = new List<PartEntity>();
                foreach (var woj in woh.WOJ_List)
                {
                    partList.AddRange(woj.WOJ_PartList);

                    partList.AddRange(woj.WOJ_KitList.SelectMany(kit => kit.WOJ_PartList));
                }

                foreach (var part in partList)
                {
                    //check if parts is available in storage
                }

                c.SaveChanges();
            }
        }

        // ----------WOJ------------
        [HttpGet]
        [Route("GetWoJobList")]
        public string GetWoJobList(string wohid)
        {
            using (var c = new DBContext())
            {
                var wohList = WohListData.GetWojList(GetWoh(wohid, c));
                return wohList;
            }
        }

        [HttpPost]
        [Route("PostWoJ")]
        public void PostWoJ(string wohId)
        {
            using (var c = new DBContext())
            {
                var woh = GetWoh(wohId, c);
                var woj = new WoJobEntity();
                if (woh.WOJ_List.Count > 0)
                {
                    var woJobEntity = woh.WOJ_List.OrderByDescending(p => p.WoJNr).FirstOrDefault();
                    if (woJobEntity != null)
                        woj.WoJNr = woJobEntity.WoJNr + 1;
                }
                else
                {
                    woj.WoJNr = 0;
                }
                woh.WOJ_List.Add(woj);
                c.SaveChanges();
            }
        }

        [HttpPost]
        [Route("RemoveWoJ")]
        public void RemoveWoJ(string wohId, string wojId)
        {
            using (var c = new DBContext())
            {
                var woj = GetWoJ(wohId, wojId, c);
                c.WorkOrderJobs.Remove(woj);
                c.SaveChanges();
            }
        }

        [HttpGet]
        [Route("GetWoJ")]
        public WoJobDto GetWoJ(string wohid, string wojid)
        {
            using (var c = new DBContext())
            {
                var woj = GetWoJ(wohid, wojid, c);
                WoJobDto woDto = Mapper.Map<WoJobEntity, WoJobDto>(woj);

                return woDto;
            }
        }

        [HttpPost]
        [Route("PostWoJData")]
        public void PostWoJData(WoJobDtoExtended statusData)
        {
            using (var c = new DBContext())
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
                return GetWoh(wohid, c).WOJ_List.Single(p => p.WoJNr.ToString() == wojid);
            }
            catch (Exception)
            {
                return new WoJobEntity();
            }
        }

        // ----------WJK------------
        [HttpGet]
        [Route("GetWJKList")]
        public string GetWJKList(string wohId, string wojId)
        {
            using (var c = new DBContext())
            {
                var wjkList = GetWoJ(wohId, wojId, c).WOJ_KitList;

                return WohListData.GetWjkList(wjkList);
            }
        }

        [HttpPost]
        [Route("AddWJK")]
        public void AddWJK(string wohId, string wojId, string wjkCode)
        {

            using (var c = new DBContext())
            {
                var wjkList = GetWoJ(wohId, wojId, c).WOJ_KitList;
                wjkList.Add(new WoKitsEntity(wjkCode));
                c.SaveChanges();
            }
        }

        [HttpPost]
        [Route("RemoveWJK")]
        public void RemoveWJK(string wohId, string wojId, string wjkId)
        {
            using (var c = new DBContext())
            {
                var woj = GetWoJ(wohId, wojId, c);
                var item = woj.WOJ_KitList.Single(p => p.Id.ToString() == wjkId);
                c.WorkOrderKits.Remove(item);
                c.SaveChanges();
            }
        }
        // ----------WJO------------
        [HttpGet]
        [Route("GetWJOList")]
        public string GetWJOList(string wohId, string wojId)
        {
            using (var c = new DBContext())
            {
                var wjoList = GetWoJ(wohId, wojId, c).WOJ_OPList;

                return WohListData.GetWjoList(wjoList);
            }
        }

        [HttpPost]
        [Route("AddWJO")]
        public void AddWJO(string wohId, string wojId, string wjoCode)
        {

            using (var c = new DBContext())
            {
                var wjoList = GetWoJ(wohId, wojId, c).WOJ_OPList;
                wjoList.Add(new WoOpEntitys(wjoCode));
                c.SaveChanges();
            }
        }

        [HttpPost]
        [Route("RemoveWJO")]
        public void RemoveWJO(string wohId, string wojId, string wjoId)
        {
            using (var c = new DBContext())
            {
                var woj = GetWoJ(wohId, wojId, c);
                var item = woj.WOJ_OPList.Single(p => p.Id.ToString() == wjoId);
                c.WorkOrderOperations.Remove(item);
                c.SaveChanges();
            }
        }

        // ----------WJP------------
        [HttpGet]
        [Route("GetWJPList")]
        public string GetWJPList(string wohId, string wojId)
        {
            using (var c = new DBContext())
            {
                var woj = GetWoJ(wohId, wojId, c);

                return WohListData.GetWjpList(woj);
            }
        }

        [HttpPost]
        [Route("AddWJP")]
        public void AddWJP(string wohId, string wojId, string wjpCode, string quantity)
        {
            using (var c = new DBContext())
            {
                var part = c.Parts.Single(p => p.ItemId.ToString() == wjpCode);
                var woj = GetWoJ(wohId, wojId, c);
                woj.WOJ_PartList.Add(part);

                var exist = woj.WOJ_PartList_Ids.FirstOrDefault(item => item.Id == part.ItemId);
                if (exist == null)
                {
                    woj.WOJ_PartList_Ids.Add(new IdAndAmountEntity(part.ItemId, double.Parse(quantity)));
                }
                else
                {
                    exist.Amount += double.Parse(quantity);
                }

                c.SaveChanges();
            }
        }

        [HttpPost]
        [Route("RemoveWJP")]
        public void RemoveWJP(string wohId, string wojId, string wjpId)
        {
            using (var c = new DBContext())
            {
                var woj = GetWoJ(wohId, wojId, c);
                var item = woj.WOJ_PartList.Single(p => p.Id.ToString() == wjpId);
                woj.WOJ_PartList.Remove(item);
                c.SaveChanges();
            }
        }

        // ---------Ignore----------
        [HttpGet]
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
