using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TacdisDeluxeAPI.Models
{
    public class IdAndAmountDto
    {
        public IdAndAmountDto()
        { }

        public IdAndAmountDto(int id, int amount)
        {
            Id = id;
            Amount = amount;
        }
        
        public int Id { get; set; }
        public double Amount { get; set; }
    }
}