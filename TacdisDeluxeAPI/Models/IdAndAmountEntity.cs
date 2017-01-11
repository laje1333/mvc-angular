using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TacdisDeluxeAPI.Models
{
    [Table("IdAndAmount")]
    public class IdAndAmountEntity
    {
        public IdAndAmountEntity()
        { }

        public IdAndAmountEntity(int id, double amount)
        {
            Id = id;
            Amount = amount;
        }

        [Key]
        public int TableID { get; set; }

        public int Id { get; set; }
        public double Amount { get; set; }


        [IgnoreDataMember]
        public WoJobEntity WoJob { get; set; }
    }
}