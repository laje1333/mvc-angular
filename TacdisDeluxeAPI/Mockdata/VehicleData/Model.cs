using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.Mockdata.VehicleData
{
    public class Model
    {
        private string modelname;
        //Engine
        private List<string> fuelTypes = new List<String>();
        private List<string> engineGroups = new List<String>();
        private List<string> engineDescriptions = new List<String>();
        //Transmission
        private List<string> transmissionTypes = new List<String>();
        private List<string> transmissionGroups = new List<String>();
        private List<string> transmissionDescriptions = new List<String>();

        //Transmission
        private List<string> paintTypes = new List<String>();
        private List<string> paintDescriptions = new List<String>();
        private List<string> paintGroups = new List<String>();

        //Transmission
        private List<string> interiorMaterials = new List<String>();
        private List<string> interiorDescriptions = new List<String>();
        private List<string> interiorColors = new List<String>();

        public Model(string modelname)
        {
            this.modelname = modelname;
        }

        public string getModelName()
        {
            return modelname;
        }

        //Interior:
        //Interior materials
        public void addInteriorMaterial(string material)
        {
            interiorMaterials.Add(material);
        }

        public List<String> getInteriorMaterial()
        {
            return interiorMaterials;
        }

        //Interior colordesc
        public void addInteriorDescriptions(string interiorDesc)
        {
            interiorDescriptions.Add(interiorDesc);
        }

        public List<String> getInteriorDescriptions()
        {
            return interiorDescriptions;
        }

        //Interior color
        public void addInteriorColor(string color)
        {
            interiorColors.Add(color);
        }

        public List<String> getInteriorColors()
        {
            return interiorColors;
        }

        //Paint:
        //Paint types
        public void addPaintType(string painttype)
        {
            paintTypes.Add(painttype);
        }

        public List<String> getPaintTypes()
        {
            return paintTypes;
        }

        //Paint descriptions
        public void addPaintDescription(string paintDesc)
        {
            paintDescriptions.Add(paintDesc);
        }

        public List<String> getPaintDescriptions()
        {
            return paintDescriptions;
        }

        //Paint groups
        public void addPaintGroup(string paintGroup)
        {
            paintGroups.Add(paintGroup);
        }

        public List<String> getPaintGroups()
        {
            return paintGroups;
        }

        //Transmission:
        //Transmission Types
        public void addTransmissionType(string transmissiontype)
        {
            transmissionTypes.Add(transmissiontype);
        }

        public List<String> getTransmissionTypes()
        {
            return transmissionTypes;
        }

        //Transmission Groups
        public void addTransmissionGroup(string transmissiongroup)
        {
            transmissionGroups.Add(transmissiongroup);
        }

        public List<String> getTransmissionGroups()
        {
            return transmissionGroups;
        }

        //Transmission descriptions
        public void addTransmissionDescription(string transmissiondesc)
        {
            transmissionDescriptions.Add(transmissiondesc);
        }

        public List<String> getTransmissionDescriptions()
        {
            return transmissionDescriptions;
        }


        //Engine:
        //Fuel types
        public void addFuelType(string fueltype)
        {
            fuelTypes.Add(fueltype);
        }

        public List<String> getFuelTypes()
        {
            return fuelTypes;
        }

        //Engine groups
        public void addEngineGroup(string enginegroup)
        {
            engineGroups.Add(enginegroup);
        }

        public List<String> getEngineGroups()
        {
            return engineGroups;
        }

        //Engine descriptions
        public void addEngineDescription(string engineDesc)
        {
            engineDescriptions.Add(engineDesc);
        }

        public List<String> getEngineDescriptions()
        {
            return engineDescriptions;
        }
    }
}