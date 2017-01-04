﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TacdisDeluxeAPI.Models
{
    [Table("WoOperations")]
    public class WoOpEntitys
    {
        public WoOpEntitys(string wjocode)
        {
            OPNr = int.Parse(wjocode);
        }

        [Key]
        public int Id { get; set; }
        public int OPNr { get; set; }
        public string OPDesc { get; set; }
        public double Quantity { get; set; }
        public double WorkTime { get; set; }
        public double Price { get; set; }
    }
}