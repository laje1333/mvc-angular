using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using TacdisDeluxeAPI.Mockdata.WorkOrderData;

namespace TacdisDeluxeAPI.Controllers
{
    public class WorkOrderController : ApiController
    {
        [System.Web.Http.HttpGet]
        public List<string> GetRegNr(string regnr)
        {
            if (regnr == null)
            {
                regnr = "";
            }
            List<string> responseArr = new List<string>();
            responseArr.Add(NewWorkOrderData.GetVehDesc(regnr.ToUpper()));
            responseArr.Add(NewWorkOrderData.GetVehRegDate(regnr.ToUpper()));
            responseArr.Add(NewWorkOrderData.GetOwner(regnr.ToUpper()));
            responseArr.Add(NewWorkOrderData.GetDriver(regnr.ToUpper()));
            responseArr.Add(NewWorkOrderData.GetPhoneNr(regnr.ToUpper()));
            responseArr.Add(NewWorkOrderData.GetLastVisDate(regnr.ToUpper()));
            responseArr.Add(NewWorkOrderData.GetLastVisMilage(regnr.ToUpper()));
            return responseArr;

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
