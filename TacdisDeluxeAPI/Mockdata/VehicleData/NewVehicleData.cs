using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.Mockdata.VehicleData
{
    public class NewVehicleData
    {

        private Brand brand;

        public NewVehicleData(Brand brand)
        {
            this.brand = brand;
        }

        public string getModelYears()
        {
            string result = "";
            for (int i = 0; i < brand.getModelyears().Count; i++)
            {
                result += brand.getModelyears()[i].getModelYear();
                if (i < brand.getModelyears().Count - 1)
                {
                    result += ",";
                }
            }

            return result;
        }

        public string getModelsFromYear(string key)
        {
            string result = "";
            for (int i = 0; i < brand.getModelsFromYear(key).Count; i++)
            {
                result += brand.getModelsFromYear(key)[i].getModelName();
                if (i < brand.getModelsFromYear(key).Count - 1)
                {
                    result += ",";
                }
            }
            return result;
        }

        public string getPropertiesFromModel(string key, string selectedMod)
        {
            string result = "";

            Model selectedModel = brand.getSelectedModel(key, selectedMod);

            //Engine
            for (int i = 0; i < selectedModel.getFuelTypes().Count; i++)
            {
                result += selectedModel.getFuelTypes()[i];

                if (i < selectedModel.getFuelTypes().Count - 1)
                {
                    result += ",";
                }
            }
            result += "=";

            for (int i = 0; i < selectedModel.getEngineGroups().Count; i++)
            {
                result += selectedModel.getEngineGroups()[i];

                if (i < selectedModel.getEngineGroups().Count - 1)
                {
                    result += ",";
                }
            }
            result += "=";
            for (int i = 0; i < selectedModel.getEngineDescriptions().Count; i++)
            {
                result += selectedModel.getEngineDescriptions()[i];

                if (i < selectedModel.getEngineDescriptions().Count - 1)
                {
                    result += ",";
                }
            }

            //Transmission
            result += "=";
            for (int i = 0; i < selectedModel.getTransmissionTypes().Count; i++)
            {
                result += selectedModel.getTransmissionTypes()[i];

                if (i < selectedModel.getTransmissionTypes().Count - 1)
                {
                    result += ",";
                }
            }

            result += "=";
            for (int i = 0; i < selectedModel.getTransmissionGroups().Count; i++)
            {
                result += selectedModel.getTransmissionGroups()[i];

                if (i < selectedModel.getTransmissionGroups().Count - 1)
                {
                    result += ",";
                }
            }

            result += "=";
            for (int i = 0; i < selectedModel.getTransmissionDescriptions().Count; i++)
            {
                result += selectedModel.getTransmissionDescriptions()[i];

                if (i < selectedModel.getTransmissionDescriptions().Count - 1)
                {
                    result += ",";
                }
            }

            //Exterior
            result += "=";
            for (int i = 0; i < selectedModel.getPaintTypes().Count; i++)
            {
                result += selectedModel.getPaintTypes()[i];

                if (i < selectedModel.getPaintTypes().Count - 1)
                {
                    result += ",";
                }
            }

            result += "=";
            for (int i = 0; i < selectedModel.getPaintDescriptions().Count; i++)
            {
                result += selectedModel.getPaintDescriptions()[i];

                if (i < selectedModel.getPaintDescriptions().Count - 1)
                {
                    result += ",";
                }
            }

            result += "=";
            for (int i = 0; i < selectedModel.getPaintGroups().Count; i++)
            {
                result += selectedModel.getPaintGroups()[i];

                if (i < selectedModel.getPaintGroups().Count - 1)
                {
                    result += ",";
                }
            }

            //Interior
            result += "=";
            for (int i = 0; i < selectedModel.getInteriorMaterial().Count; i++)
            {
                result += selectedModel.getInteriorMaterial()[i];

                if (i < selectedModel.getInteriorMaterial().Count - 1)
                {
                    result += ",";
                }
            }

            result += "=";
            for (int i = 0; i < selectedModel.getInteriorDescriptions().Count; i++)
            {
                result += selectedModel.getInteriorDescriptions()[i];

                if (i < selectedModel.getInteriorDescriptions().Count - 1)
                {
                    result += ",";
                }
            }
            result += "=";
            for (int i = 0; i < selectedModel.getInteriorColors().Count; i++)
            {
                result += selectedModel.getInteriorColors()[i];

                if (i < selectedModel.getInteriorColors().Count - 1)
                {
                    result += ",";
                }
            }


            return result;
        }

    }
}