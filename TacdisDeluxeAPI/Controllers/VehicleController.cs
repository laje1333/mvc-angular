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

        public IHttpActionResult GetVehicleBySearch(string regNR, string itemNR, string name)
        {
            using (DBContext c = new DBContext())
            {
                IQueryable<VehicleEntity> allVeh;

                if (string.IsNullOrEmpty(regNR + itemNR + name))
                {
                    return Ok(new List<VehicleEntity>());
                }
                else
                {
                    allVeh = c.Vehicles as IQueryable<VehicleEntity>;
                }

                if (!String.IsNullOrEmpty(regNR))
                {
                    allVeh = allVeh.Where(p => p.RegNo.Contains(regNR));
                }

                if (!String.IsNullOrEmpty(itemNR))
                {
                    allVeh = allVeh.Where(p => p.ItemId.ToString().Contains(itemNR));
                }

                if (!String.IsNullOrEmpty(name))
                {
                    allVeh = allVeh.Where(p => p.ItemName.Contains(name));
                }

                return Ok(allVeh.ToList());
            }
        }

        public IEnumerable<VehicleEntity> GetAllVehicles()
        {
            using (DBContext c = new DBContext())
            {
                var vehicles = c.Vehicles;



                return vehicles.ToList();
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
        public void AddCar(NewVehicleDto vehicleData)
        {

            //props.generateRegNumber();
            VehicleEntity v = vehicleData.convertToVehicleEntity();

            using (DBContext c = new DBContext())
            {

                c.Vehicles.Add(v);
                c.SaveChanges();

            }
        }

        // PUT: api/Vehicle/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Vehicle/5
        [System.Web.Http.HttpDelete]
        public void Delete(string regNumber)
        {
            using (DBContext c = new DBContext())
            {

                var vehicle = c.Vehicles.Where(x => x.RegNo == regNumber).Single();

                c.Vehicles.Remove(vehicle);
                c.SaveChanges();

            }
        }
    }
}
