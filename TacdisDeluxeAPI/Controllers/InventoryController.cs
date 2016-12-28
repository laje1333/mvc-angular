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
        public IEnumerable<InventoryDto> GetAllWorkshopItems()
        {
            using (DBContext c = new DBContext())
            {

                //InventoryData d1 = new InventoryData();
                //d1.Amount = 128;
                //d1.Part = "Screw";
                //d1.WorkshopAmount = 275;

                //InventoryData d2 = new InventoryData();
                //d2.Amount = 34;
                //d2.Part = "Pipe";
                //d2.WorkshopAmount = 75;

                //InventoryData d3 = new InventoryData();
                //d3.Amount = 512;
                //d3.Part = "Rubber tube";
                //d3.WorkshopAmount = 89;

                //List<InventoryData> data = new List<InventoryData>();
                //data.Add(d1);
                //data.Add(d2);
                //data.Add(d3);

                //return data;
                

                //First get the workshop id of your current workshop from the sessionmanager
                int workshopId = 1;

                List<WorkshopInventoryItem> inventoryItems = c.WorkshopInventoryItems.Where(x => x.WorkshopId == workshopId).ToList();

                List<InventoryDto> invDto = new List<InventoryDto>();

                for (int i = 0; i < inventoryItems.Count; i++)
                {
                    InventoryDto d = new InventoryDto();

                    int prtID = inventoryItems[i].PartId;

                    string p = c.Parts.Where(x => x.ItemId == prtID).Select(x => x.ItemName).Single();
                    d.PartName = p;
                    d.WorkshopInventoryAmount = inventoryItems[i].Amount;
                    d.MainInventoryAmount = c.MainInventoryItems.Where(x => x.PartId == prtID).Select(x => x.Amount).Single();

                    invDto.Add(d);
                }


                return invDto;




                //Return InventoryDto

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
