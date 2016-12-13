using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using TacdisDeluxeAPI.Mockdata.VehicleData;

namespace TacdisDeluxeAPI.Controllers
{
    public class VehicleController : ApiController
    {
        // GET: api/Vehicle



        // GET: api/Vehicle/5




        //id = brand, panel = model/engine/transmission...
        
        public string GetVehicleInfo(string brand)
        {
           
            return NewVehicleDataHash.getValue(brand).getModelYears();
        }

        public string GetVehicleInfo(string modelyear, string brand)
        {
            return NewVehicleDataHash.getValue(brand).getModelsFromYear(modelyear);
        }

        public string GetVehicleInfo(string model, string modelyear, string brand)
        {
            return NewVehicleDataHash.getValue(brand).getPropertiesFromModel(modelyear, model);
        }


        // POST: api/Vehicle
        [System.Web.Http.HttpPost]
        public void AddCar(NewVehicleProperties properties)
        {
            NewVehicleProperties.addVehicleToRecord(properties);
        }

        // PUT: api/Vehicle/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Vehicle/5
        public void Delete(int id)
        {
        }
    }
}
