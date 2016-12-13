using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.Mockdata.VehicleData
{
    public class Brand
    {
        private Dictionary<String, ModelYear> modelyears = new Dictionary<String, ModelYear>();
        private string brand;

        public Brand(string brand)
        {
            this.brand = brand;
        }



        public void addModelYear(ModelYear mYear)
        {
            modelyears.Add(mYear.getModelYear(), mYear);
        }

        public List<ModelYear> getModelyears()
        {
            return modelyears.Values.ToList();
        }

        public List<Model> getModelsFromYear(string key)
        {
            return modelyears[key].getModels();
        }

        public string getBrand()
        {
            return this.brand;
        }

        public Model getSelectedModel(string key, string selectedModel)
        {
            return modelyears[key].getSelectedModel(selectedModel);
        }
    }
}