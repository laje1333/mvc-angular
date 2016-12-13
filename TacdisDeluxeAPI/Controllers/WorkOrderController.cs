using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Mvc;
using TacdisDeluxeAPI.Mockdata.WorkOrderData;

namespace TacdisDeluxeAPI.Controllers
{
    public class WorkOrderController : ApiController
    {
        [System.Web.Http.HttpGet]
        public List<string> GetNewWO(string addNew)
        {
            List<string> responseArr = new List<string>();
            switch (addNew)
            {
                case "WOH":
                    responseArr.Add(NewWorkOrderData.GetNewWOH());
                    NewWoJobData.ResetWoJID();
                    break;
                case "WOJ":
                    responseArr.Add(NewWoJobData.GetNewWOJ());
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
                    responseArr.Add(NewWorkOrderData.GetCurrentWOH());
                    break;
                case "WOJ":
                    responseArr.Add(NewWoJobData.GetCurrentWOJ());
                    break;
                default:
                    break;
            }

            return responseArr;
        }

        [System.Web.Http.HttpGet]
        public List<string> GetRegNr(string WOH, string regnr)
        {
            List<string> responseArr = new List<string>();
            if (!ValidateRegNr(regnr))
            {
                regnr = "";
            }
            responseArr.Add(NewWorkOrderData.GetVehDesc(regnr.ToUpper()));
            responseArr.Add(NewWorkOrderData.GetVehRegDate(regnr.ToUpper()));
            responseArr.Add(NewWorkOrderData.GetOwner(regnr.ToUpper()));
            responseArr.Add(NewWorkOrderData.GetDriver(regnr.ToUpper()));
            responseArr.Add(NewWorkOrderData.GetPhoneNr(regnr.ToUpper()));
            responseArr.Add(NewWorkOrderData.GetLastVisDate(regnr.ToUpper()));
            responseArr.Add(NewWorkOrderData.GetLastVisMilage(regnr.ToUpper()));

            //SetCurrentCar(WOH, regnr);

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
        public void Post([FromBody]string value)
        {
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
