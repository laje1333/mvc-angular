using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls.WebParts;
using TacdisDeluxeAPI.DTO;
using TacdisDeluxeAPI.Mockdata.VehicleData;
using TacdisDeluxeAPI.Models;

namespace TacdisDeluxeAPI.Controllers
{
    public class InventoryController : ApiController
    {
        // GET: api/Inventory
        public IEnumerable<InventoryData> GetAllWorkshopItems()
        {
            using (DBContext c = new DBContext())
            {

                InventoryData d1 = new InventoryData();
                d1.Amount = 128;
                d1.Part = "Screw";
                d1.WorkshopAmount = 275;

                InventoryData d2 = new InventoryData();
                d2.Amount = 34;
                d2.Part = "Pipe";
                d2.WorkshopAmount = 75;

                InventoryData d3 = new InventoryData();
                d3.Amount = 512;
                d3.Part = "Rubber tube";
                d3.WorkshopAmount = 89;

                List<InventoryData> data = new List<InventoryData>();
                data.Add(d1);
                data.Add(d2);
                data.Add(d3);

                return data;
                //int workshopId = 1;
                ////Filtering only needs on the following line, since everything is dependancies of it.
                //List<WorkshopInventoryPartEntity> WspInvPrtEnts = c.WorkshopInventoryPartConnections.Where(x => x.WorkshopId == workshopId).ToList();

                //List<InventoryDto> WspInvEnts = new List<InventoryDto>();
                //for (int i = 0; i < WspInvPrtEnts.Count; i++)
                //{
                //    PartEntity p = c.Parts.Where(x => x.ItemId == WspInvPrtEnts[i].PartId).Single();
                //    InventoryDto IDto = new InventoryDto();
                //    IDto.Name = p.ItemName;
                //    IDto.WorkshopAmount = WspInvPrtEnts[i].Count;

                //    IDto.MainInventoryAmount = c.MainInventoryPartConnections.Where(x => x.PartId == WspInvPrtEnts[i].PartId).Select(x => x.Count).Single();
                //    WspInvEnts.Add(IDto);
                //}

                //return WspInvEnts;
            }
        }


        // POST: api/Inventory
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Inventory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Inventory/5
        public void Delete(int id)
        {
        }
    }
}
