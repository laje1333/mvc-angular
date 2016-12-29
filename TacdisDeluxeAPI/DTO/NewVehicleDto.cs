using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TacdisDeluxeAPI.Models;

namespace TacdisDeluxeAPI.DTO
{
    public class NewVehicleDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string ModelYear { get; set; }

        public List<VehiclePropertyEntity> Properties { get; set; }



        public int cost = 0;



        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private string generateRegNumber()
        {
            Random r = new Random();
            string letters = new string(Enumerable.Repeat(chars, 3)
                .Select(s => s[r.Next(s.Length)]).ToArray());
            string numbers = r.Next(100,999).ToString();

            return letters + numbers;
        }

        public VehicleEntity convertToVehicleEntity()
        {
            VehicleEntity v = new VehicleEntity();
            v.ItemPrice = 205000;
            v.ItemDesc = "";
            for (int i = 0; i < Properties.Count; i++)
            {
                v.ItemPrice += Properties[i].Price;
                if (Properties[i].Field.Contains("Description"))
                {
                    v.ItemDesc += Properties[i].Name + "\n";
                }
            }

            v.RegNo = generateRegNumber();
            v.VAT = 0.25f;
            v.ItemName = Brand + " " + ModelYear + " " + Model;
            v.ItemId = new Random().Next(999999);



            return v;
            
        }


    }
}