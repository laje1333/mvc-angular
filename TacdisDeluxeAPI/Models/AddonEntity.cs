﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TacdisDeluxeAPI.Models
{
    public class AddonEntity
    {
        [Key]
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public string ItemDesc { get; set; }
        public double VAT { get; set; }

        [IgnoreDataMember]
        public ICollection<SaleEntity> Sales { get; internal set; }
    }
}
