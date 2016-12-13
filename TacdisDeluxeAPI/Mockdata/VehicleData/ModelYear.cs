using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.Mockdata.VehicleData
{
    public class ModelYear
    {
        private List<Model> models = new List<Model>();
        private string modelyear;

        public ModelYear(string modelyear)
        {
            this.modelyear = modelyear;
        }

        public void addModel(Model m)
        {
            models.Add(m);
        }

        public List<Model> getModels()
        {
            return models;
        }

        public string getModelYear()
        {
            return this.modelyear;
        }

        public Model getSelectedModel(string selectedModelType)
        {
            Model m = null;
            for (int i = 0; i < models.Count; i++)
            {
                if (models[i].getModelName().Equals(selectedModelType))
                {
                    m = models[i];
                    break;
                }
            }
            return m;
        }
    }
}