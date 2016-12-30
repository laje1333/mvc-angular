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
        public IEnumerable<InventoryDto> GetAllWorkshopItems(string partName)
        {
            using (DBContext c = new DBContext())
            {

                //First get the workshop id of your current workshop from the sessionmanager
                int workshopId = 1;

                List<WorkshopInventoryItem> inventoryItems;



                inventoryItems = c.WorkshopInventoryItems.Where(x => x.WorkshopId == workshopId).ToList();
                

                List<InventoryDto> invDto = new List<InventoryDto>();

                int index = 10;

                if (inventoryItems.Count < 10)
                {
                    index = inventoryItems.Count;
                }

                if (!String.IsNullOrEmpty(partName))
                {
                    for (int i = 0; i < index; i++)
                    {
                        InventoryDto d = new InventoryDto();

                        int prtID = inventoryItems[i].PartId;

                        PartEntity p = c.Parts.Where(x => x.ItemId == prtID && x.ItemName.Contains(partName)).SingleOrDefault();
                        if (p != null)
                        {
                            d.PartName = p.ItemName;
                            d.WorkshopInventoryAmount = inventoryItems[i].Amount;
                            d.MainInventoryAmount = c.MainInventoryItems.Where(x => x.PartId == prtID).Select(x => x.Amount).Single();
                            d.itemID = p.ItemId;
                            invDto.Add(d);
                        }
                      
                    }
                }
                else
                {
                    for (int i = 0; i < inventoryItems.Count; i++)
                    {
                        InventoryDto d = new InventoryDto();

                        int prtID = inventoryItems[i].PartId;

                        PartEntity p = c.Parts.Where(x => x.ItemId == prtID).Single();
                        d.PartName = p.ItemName;
                        d.WorkshopInventoryAmount = inventoryItems[i].Amount;
                        d.MainInventoryAmount = c.MainInventoryItems.Where(x => x.PartId == prtID).Select(x => x.Amount).Single();
                        d.itemID = p.ItemId;
                        invDto.Add(d);
                    }
                }




                return invDto;




                //Return InventoryDto

            }
        }


        // POST: api/Inventory
        [System.Web.Http.HttpPost]
        public void PostTransfer(ICollection<InventoryTableData> invData)
        {
            using (DBContext c = new DBContext())
            {
                if (invData != null) { 
                for (int i = 0; i < invData.Count; i++)
                {
                    int itemId = invData.ToList()[i].ItemID;
                    int amount = invData.ToList()[i].Amount;
                    c.WorkshopInventoryItems.Where(x => x.PartId == itemId).Single().Amount += amount;
                    c.MainInventoryItems.Where(x => x.PartId == itemId).Single().Amount -= amount;
                }
                c.SaveChanges();
            }
            }
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
