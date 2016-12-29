using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.DTO
{
    public class InventoryTableData
    {


        public string Name {get;set;}
        public int Amount {get;set;}    //Main inventory amount
        public int ItemID {get;set;}
    }
}