using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TacdisDeluxeAPI.Models;

namespace TacdisDeluxeAPI.DTO
{
    public class NewVehicleDto
    {


        public string REGNR = "1";
        public int cost = 0;



        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public void generateRegNumber()
        {
            Random r = new Random();
            string letters = new string(Enumerable.Repeat(chars, 3)
                .Select(s => s[r.Next(s.Length)]).ToArray());
            string numbers = r.Next(999).ToString();

            REGNR = letters + numbers;
        }



    }
}