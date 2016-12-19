using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using TacdisDeluxeAPI.DTO;
using TacdisDeluxeAPI.Mockdata.VehicleData;
using TacdisDeluxeAPI.Models;

namespace TacdisDeluxeAPI.Controllers
{
    public class VehicleController : ApiController
    {
        // GET: api/Vehicle



        // GET: api/Vehicle/5

        public IEnumerable<String> GetVehicleModels(string brand)
        {
            using (DBContext c = new DBContext())
            {
                var models = c.VehicleModels.Include("Properties").Distinct().Where(x => x.Brand.Name == brand).Select(x => x.Name);



                return models.ToList();
            }
        }

        public IEnumerable<int> GetModelYear(string model)
        {
            using (DBContext c = new DBContext())
            {
                var models = c.VehicleModels.Include("Properties").Distinct().Where(x => x.Name == model).Select(x => x.ProductionDate.Year);



                return models.ToList();
            }
        }
        public IEnumerable<VehiclePropertyEntity> GetModelProperties(int year, string mod, string brnd)
        {
            using (DBContext c = new DBContext())
            {
                var models = c.VehicleModels.Include("Properties").Distinct().Where(x => (x.Name == mod && x.Brand.Name == brnd && x.ProductionDate.Year == year)).Single().Properties;



                return models.ToList();
            }
        }

        
        //public string GetVehicleInfo(string brand)
        //{
           
        //    return NewVehicleDataHash.getValue(brand).getModelYears();
        //}

        //public string GetVehicleInfo(string modelyear, string brand)
        //{
        //    return NewVehicleDataHash.getValue(brand).getModelsFromYear(modelyear);
        //}

        //public string GetVehicleInfo(string model, string modelyear, string brand)
        //{
        //    return NewVehicleDataHash.getValue(brand).getPropertiesFromModel(modelyear, model);
        //}

        //public string GetVehicleMaintenanceList()
        //{
        //    return NewVehicleProperties.getNewVehicles();
        //}
        


        // POST: api/Vehicle
        [System.Web.Http.HttpPost]
        public void AddCar(NewVehicleDto props)
        {

            props.generateRegNumber();
            

            using (DBContext c = new DBContext())
            {

                //Generate reg nr


                //c.Vehicles.Add(vehicle);

            }
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
